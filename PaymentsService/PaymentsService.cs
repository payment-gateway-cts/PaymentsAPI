using System;
using System.Collections.Generic;
using PaymentsAPI.Interfaces;
using System.Linq;
using PaymentsAPI.DataModel;
using PaymentsAPI.DataModel.Entities;
using PaymentsAPI.BusinessModels;
using static PaymentsAPI.BusinessModels.PaymentEnums;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
    
namespace PaymentsAPI.Service
{
    public class PaymentsService : IPaymentsService
    {
        private readonly PaymentDBContext _context;
        private IDistributedCache _cache;

        public PaymentsService(PaymentDBContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public IEnumerable<AccountBM> GetAccounts()
        {
            //ToDo: Use Automapper for entity to Business Model conversion
            return _context.Account.Select(accNtt => new AccountBM
            {
                Id = accNtt.Id,
                AccountNumber = accNtt.AccountNumber,
                AccountType = accNtt.AccountType.AccountType1,
                Name = accNtt.AccountName,
                CustomerName = accNtt.Customer.LastName + ", " + accNtt.Customer.FirstName,
                Currency = accNtt.Currency,
                IBAN = accNtt.Iban,
                CurrentBalance = accNtt.CurrentBalance
            });
        }

        public IEnumerable<PaymentBM> GetPayments()
        {
            var payments = (from pay in _context.Payment
                            join payoracc in _context.Account on pay.PayorAccountId equals payoracc.Id
                            join payorcus in _context.Customer on pay.PayorCustomerId equals payorcus.Id
                            join payeeacc in _context.Account on pay.PayorAccountId equals payeeacc.Id
                            join payeecus in _context.Customer on pay.PayorCustomerId equals payeecus.Id
                            join pm in _context.PaymentMethod on pay.PaymentMethodId equals pm.Id
                            join sts in _context.PaymentStatus on pay.PaymentStatusId equals sts.Id
                            select new PaymentBM
                            {
                                PayeeName = $" {payeecus.LastName}, {payeecus.FirstName}",
                                PayorName = $" {payorcus.LastName}, {payorcus.FirstName}",
                                PayorAccountNumber = payoracc.AccountNumber,
                                PayeeAccountNumber = payeeacc.AccountNumber,
                                TransactionId = pay.TransactionId,
                                TransactionType = pay.TransactionType,
                                Amount = pay.PaymentAmount,
                                PayorCurrency = payoracc.Currency,
                                PayeeCurrency = payeeacc.Currency,
                                PaymentDate = pay.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                PaymentMethod = pm.PaymentMethodName,
                                PaymentStatus = sts.Status
                            }).ToList();

            return payments;
        }

        public string MakePayment(PaymentBM payment)
        {
            Payment newPayment = null;

            //Payment to this account
            var payeeAccount = _context.Account.Where(x => x.AccountNumber == payment.PayeeAccountNumber).FirstOrDefault();

            //Payment from this account
            var payorAccount = _context.Account.Where(x => x.AccountNumber == payment.PayorAccountNumber).FirstOrDefault();

            string transactionId = "";

            if (payorAccount != null && payeeAccount != null)
            {
                var paymentMethodId = _context.PaymentMethod.Where(x => x.PaymentMethodCode == payment.PaymentMethod).Select(x => x.Id).FirstOrDefault();
                var statusId = _context.PaymentStatus.Where(x => x.Status == PaymentSatus.Completed.ToString()).Select(x => x.Id).FirstOrDefault();

                //ToDo: Below needs to be reviewed and removed if not needed
                transactionId = PaymentHelper.GenerateTransactionId();
                if (_context.Payment.Any(x => x.TransactionId == transactionId))
                {
                    transactionId = PaymentHelper.GenerateTransactionId();
                }


                payeeAccount.CurrentBalance = payment.TransactionType == TransactionType.Credit.ToString()
                                                ? payeeAccount.CurrentBalance + payment.Amount
                                                : payeeAccount.CurrentBalance - payment.Amount;

                payorAccount.CurrentBalance = payment.TransactionType == TransactionType.Credit.ToString()
                                                ? payorAccount.CurrentBalance - payment.Amount
                                                : payorAccount.CurrentBalance + payment.Amount;

                newPayment = new Payment
                {
                    PayorAccountId = payorAccount.Id,
                    PayorCustomerId = payorAccount.CustomerId.Value,
                    PayeeAccountId = payeeAccount.Id,
                    PayeeCustomerId = payeeAccount.CustomerId.Value,
                    PaymentMethodId = paymentMethodId,
                    PaymentStatusId = statusId,
                    PaymentAmount = payment.Amount,
                    TransactionId = transactionId,
                    PaymentDate = payment.PaymentDate.IsDate() ? Convert.ToDateTime(payment.PaymentDate) : DateTime.Now,
                    TransactionType = payment.TransactionType,
                    Remarks = $"Amount {payment.Amount.ToString()} has been {payment.TransactionType}ed to account {payment.PayeeAccountNumber}. The current balance is {payeeAccount.CurrentBalance} in Payee account {payment.PayeeAccountNumber}. The current balance is {payorAccount.CurrentBalance} in Payor account {payment.PayeeAccountNumber}."
                };
                _context.Payment.Add(newPayment);

                _context.SaveChanges();
            }

            return newPayment != null && newPayment.Id != null ? transactionId : string.Empty;
        }

        public string GetCurrency(string accountNumber)
        {
            return _context.Account.Where(x => x.AccountNumber == accountNumber).Select(x => x.Currency).FirstOrDefault();
        }

        public decimal GetCurrencyExchangeRates(string fromCurrency, string toCurrency)
        {
            try
            {

                List<CurrencyExchangeRates> currencyRates;

                //Retrieve currency rates from cache
                var currencyRatesCahed = _cache.GetString("ccyRates");

                if (!string.IsNullOrEmpty(currencyRatesCahed))
                {
                    currencyRates = JsonConvert.DeserializeObject<List<CurrencyExchangeRates>>(currencyRatesCahed);
                }
                else
                {
                    currencyRates = _context.CurrencyExchangeRates.ToList();

                    //Cache Invalidation policy.. expires every 5 mins
                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                    options.SetAbsoluteExpiration(new TimeSpan(0, 5, 0));

                    //Set the cache with latest values;
                    _cache.SetString("ccyRates", JsonConvert.SerializeObject(currencyRates));

                }

                var fromCurrRates = currencyRates.Where(x => x.CurrencyCode == fromCurrency).Select(x => x.ExchangeRate).FirstOrDefault();
                var toCurrRates = currencyRates.Where(x => x.CurrencyCode == toCurrency).Select(x => x.ExchangeRate).FirstOrDefault();

                return (toCurrRates / fromCurrRates);

                /*
                var currencyRatesTable = _context.CurrencyExchangeRates.ToList();
                var fromCurrRates = currencyRatesTable.Where(x => x.CurrencyCode == fromCurrency).Select(x => x.ExchangeRate).FirstOrDefault();
                var toCurrRates = currencyRatesTable.Where(x => x.CurrencyCode == toCurrency).Select(x => x.ExchangeRate).FirstOrDefault();
                return (toCurrRates / fromCurrRates);
                */

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
