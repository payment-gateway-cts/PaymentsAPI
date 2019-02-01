using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsAPI.BusinessModels
{
    public class PaymentBM
    {
        public string PayeeAccountNumber { get; set; }
        public string PayeeCurrency { get; set; }

        public string PayorAccountNumber { get; set; }
        public string PayorCurrency { get; set; }

        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }       
        public string PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
