using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class Payment
    {
        public Guid Id { get; set; }
        public long AccountId { get; set; }
        public long CustomerId { get; set; }
        public long PaymentMethodId { get; set; }
        public long PaymentStatusId { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }

        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public string Remarks { get; set; }
    }
}
