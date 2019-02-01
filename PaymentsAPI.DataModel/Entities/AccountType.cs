using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class AccountType
    {
        public AccountType()
        {
            Account = new HashSet<Account>();
        }

        public long Id { get; set; }
        public string AccountType1 { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
