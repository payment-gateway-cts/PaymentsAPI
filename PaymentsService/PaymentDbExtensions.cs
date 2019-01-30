using PaymentsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentsAPI.Services
{
    public static class PaymentDBExtensions
    {
        public static void EnsureSeedDataForContext(this PaymentDbContext context)
        {
            //If the DB has no data then return. Otherwise populate some data for unit testing during development
            if (context.Payments.Any()) return;

            List<Payment> payments = new List<Payment>()
            {
                new Payment { TransactionDate= DateTime.Now.AddDays(-4), Payer="Payer 1", Payee="Payee 2", Amount=501, PayCurrency="USD", USDAmount=501},
                new Payment { TransactionDate= DateTime.Now.AddDays(-3), Payer="Payer 2", Payee="Payee 1", Amount=101, PayCurrency="USD", USDAmount=101},
                new Payment { TransactionDate= DateTime.Now.AddDays(-2), Payer="Payer 1", Payee="Payee 2", Amount=375, PayCurrency="USD", USDAmount=375},
                new Payment { TransactionDate= DateTime.Now.AddDays(-1), Payer="Payer 2", Payee="Payee 1", Amount=302, PayCurrency="USD", USDAmount=302},
                new Payment { TransactionDate= DateTime.Now, Payer="Payer 1", Payee="Payee 2", Amount=420, PayCurrency="USD", USDAmount=420}
            };
            context.Payments.AddRange(payments);
            context.SaveChanges();
        }
    }
}
