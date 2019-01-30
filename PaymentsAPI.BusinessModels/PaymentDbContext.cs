using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentsAPI.BusinessModels
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
