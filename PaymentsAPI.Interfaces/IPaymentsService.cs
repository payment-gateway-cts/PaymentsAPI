using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.Interfaces
{
    public interface IPaymentsService
    {
        /*IEnumerable<Payment> GetAllPaymentsList();
        Payment MakePayment(Payment newPayment);
        Payment GetPaymentById(int transactionId);
        int PurgePayments();*/
        IEnumerable<CustomerBM> GetCustomers();

        IEnumerable<AccountTypeBM> GetAccountTypes();

        IEnumerable<AccountBM> GetAccounts();

        IEnumerable<PaymentMethodBM> GetPaymentMethods();

        IEnumerable<PaymentBM> GetPayments();

        string MakePayment(PaymentBM payment);

        string GetCurrency(string accountNumber);

        decimal GetCurrencyExchangeRate(string fromCurrency, string toCurrency);

    }
}
