using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Payment = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public ICollection<Payment> Payment { get; set; }
    }
}
