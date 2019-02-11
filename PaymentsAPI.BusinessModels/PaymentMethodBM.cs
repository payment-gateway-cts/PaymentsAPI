using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.BusinessModels
{
    public class PaymentMethodBM
    {
        public long Id { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodCode { get; set; }
    }
}
