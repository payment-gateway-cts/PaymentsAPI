using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class CustomerPaymentMethod
    {
        public long CustomerId { get; set; }
        public long PaymentMethodId { get; set; }
        public string CardNumber { get; set; }
        public DateTime? CardExpiryDate { get; set; }
        public string CardSecurityNumber { get; set; }

        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
