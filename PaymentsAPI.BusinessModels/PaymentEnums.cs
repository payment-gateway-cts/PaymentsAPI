using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsAPI.BusinessModels
{
    public static class PaymentEnums
    {
        public enum PaymentType
        {
            Saving ,
            Current
        }

        public enum PaymentSatus
        {
            Completed,
            Cancelled,
            Rejected
        }

        public enum PaymentMethod
        {
             CreditCard,
             DebitCard,
             InternateBanking
        }

        public enum TransactionType
        {
            Credit,
            Debit
        }

        public enum Currency
        {
            USD,
            EUR,
            GBP,
            JPY,
            CHF,
            CAD,
            AUD,
            INR
        }
    }
}
