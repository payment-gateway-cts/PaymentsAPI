using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.BusinessModels
{
    public class CustomerBM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
