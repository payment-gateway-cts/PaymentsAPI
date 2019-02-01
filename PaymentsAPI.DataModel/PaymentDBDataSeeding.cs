using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PaymentsAPI.DataModel.Entities;

namespace PaymentsAPI.DataModel
{
    public static class PaymentDBDataSeeding
    {
        public static void EnsureSeedDataForContext(this PaymentDBContext context)
        {
            if(!context.AccountType.Any())
            {
                List<AccountType> accountTypes = new List<AccountType> {
                    new AccountType { AccountType1 = "Saving"},
                    new AccountType { AccountType1 = "Current"}
                };
                context.AccountType.AddRange(accountTypes);
            }

            if(!context.PaymentMethod.Any())
            {
                List<PaymentMethod> paymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { PaymentMethodName = "CreditCard", PaymentMethodCode="CC"},
                    new PaymentMethod { PaymentMethodName = "DebitCard", PaymentMethodCode ="DB"},
                    new PaymentMethod { PaymentMethodName = "InternetBanking", PaymentMethodCode="IB"}
                };
                context.PaymentMethod.AddRange(paymentMethods);
            }

            if(!context.PaymentStatus.Any())
            {
                List<PaymentStatus> paymentStatuses = new List<PaymentStatus>
                {
                    new PaymentStatus { Status="Completed"},
                    new PaymentStatus { Status="Cancelled"},
                    new PaymentStatus { Status="Rejected"}
                };
                context.PaymentStatus.AddRange(paymentStatuses);
            }

            context.SaveChanges();

            if(!context.Account.Any())
            {
                List<Account> accounts = new List<Account>
                {

                };
            }

            if(!context.Customer.Any())
            {
                List<Customer> customers = new List<Customer>
                {
                    new Customer { }
                };
            }
        }
    }
}
