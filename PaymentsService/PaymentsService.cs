using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using PaymentsAPI.Interfaces;

namespace PaymentsAPI.Service
{
    public class PaymentsService : IPaymentsService
    {
        public IEnumerable<Account> GetAccounts()
        {
            var accs = new List<Account>
            {
                new Account
                {
                    AccountType = "Savings",
                    BIC = "AAAAAAAAAAA",
                    Currency = "EUR",
                    IBAN = "CH99 1111 2222 3333 4444",
                    Id = Guid.NewGuid().ToString(),
                    Name = "My Savings Account",
                    Product = "Bonviva Platinum Savings"
                },

                new Account
                {
                    AccountType = "Savings",
                    BIC = "BBBBBBBBBBB",
                    Currency = "EUR",
                    IBAN = "CH99 5555 6666 7777 8888",
                    Id = Guid.NewGuid().ToString(),
                    Name = "Project Savings Account",
                    Product = "Bonviva Golden Savings"
                },

                new Account
                {
                    AccountType = "Savings",
                    BIC = "CCCCCCCCCC",
                    Currency = "CHF",
                    IBAN = "CH99 9999 8888 7777 6666",
                    Id = Guid.NewGuid().ToString(),
                    Name = "My First Savings Account",
                    Product = "Bonviva Silver Savings"
                }
            };

            return accs;
        }
    }
}
