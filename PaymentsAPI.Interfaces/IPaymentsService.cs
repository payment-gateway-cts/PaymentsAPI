using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.Interfaces
{
    public interface IPaymentsService
    {
        IEnumerable<Account> GetAccounts();
    }
}
