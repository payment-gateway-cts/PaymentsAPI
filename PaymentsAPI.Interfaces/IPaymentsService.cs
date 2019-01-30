using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.Interfaces
{
    public interface IPaymentsService
    {
        IEnumerable<Payment> GetAllPaymentsList();
        Payment MakePayment(Payment newPayment);
        Payment GetPaymentById(int transactionId);
        int PurgePayments();
        IEnumerable<Account> GetAccounts();
    }
}
