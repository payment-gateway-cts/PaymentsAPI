using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
            CustomerPaymentMethods = new HashSet<CustomerPaymentMethod>();
            Payment = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
