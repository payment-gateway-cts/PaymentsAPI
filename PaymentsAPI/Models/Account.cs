using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsAPI.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Product { get; set; }
        public AccountTypes AccountType { get; set; }
        public string BIC { get; set; }
    }

    public enum AccountTypes
    {
        Saving,
        Private
    }
}
