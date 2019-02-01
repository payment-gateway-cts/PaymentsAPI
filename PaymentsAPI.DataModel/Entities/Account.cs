using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class Account
    {
        public Account()
        {
            Payment = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string AccountName { get; set; }
        public long AccountTypeId { get; set; }
        public string Iban { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal? CurrentBalance { get; set; }

        public AccountType AccountType { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
