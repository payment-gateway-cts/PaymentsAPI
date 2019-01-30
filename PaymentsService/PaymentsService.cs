using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using PaymentsAPI.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace PaymentsAPI.Service
{
    public class PaymentsService : IPaymentsService
    {
        private PaymentDbContext _dbContext;

        public PaymentsService(PaymentDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Payment> GetAllPaymentsList()
        {
            var payments = _dbContext.Payments.OrderByDescending(pymt => pymt.TransactionDate).ToList();
            return payments;
        }

        public Payment MakePayment(Payment newPayment)
        {
            _dbContext.Payments.Add(newPayment);
            _dbContext.SaveChanges();
            return newPayment; //return with newly generated primary key
        }

        public Payment GetPaymentById(int transactionId)
        {
            return _dbContext.Payments.Find(transactionId);
        }

        public int PurgePayments() //Used only for deleting junk payments used for testing
        {
            var allPayments = _dbContext.Payments.ToArray();
            for (int i = allPayments.Length - 1; i > -1; i--)
            {
                _dbContext.Payments.Remove(allPayments[i]);
            }
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Account> GetAccounts()
        {
            var accs = new List<Account>
            {
                new Account
                {
                    AccountType = "Savings",
                    BIC = "AAAAAAAAAAA",
                    Currency = "EUR",
                    IBAN = "CH99 1111 2222 3333 4444",
                    Id = Guid.NewGuid().ToString(),
                    Name = "My Savings Account",
                    Product = "Bonviva Platinum Savings"
                },

                new Account
                {
                    AccountType = "Savings",
                    BIC = "BBBBBBBBBBB",
                    Currency = "EUR",
                    IBAN = "CH99 5555 6666 7777 8888",
                    Id = Guid.NewGuid().ToString(),
                    Name = "Project Savings Account",
                    Product = "Bonviva Golden Savings"
                },

                new Account
                {
                    AccountType = "Savings",
                    BIC = "CCCCCCCCCC",
                    Currency = "CHF",
                    IBAN = "CH99 9999 8888 7777 6666",
                    Id = Guid.NewGuid().ToString(),
                    Name = "My First Savings Account",
                    Product = "Bonviva Silver Savings"
                }
            };

            return accs;
        }
    }
}
