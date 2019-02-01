using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CustomerPaymentMethods = new HashSet<CustomerPaymentMethod>();
            Payment = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodCode { get; set; }

        public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
