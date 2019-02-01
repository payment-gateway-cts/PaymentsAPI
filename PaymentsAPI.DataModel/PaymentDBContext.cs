using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PaymentsAPI.DataModel.Entities;

namespace PaymentsAPI.DataModel
{
    public partial class PaymentDBContext : DbContext
    {
        public PaymentDBContext()
        {
        }

        public PaymentDBContext(DbContextOptions<PaymentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPaymentMethod> CustomerPaymentMethod { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<CurrencyExchangeRates> CurrencyExchangeRates { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-J16MIQKO\\SQLEXPRESS;Database=PaymentDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountName).HasMaxLength(100);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.CurrentBalance).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_AccountType");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Account_Customer");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.Property(e => e.AccountType1)
                    .IsRequired()
                    .HasColumnName("AccountType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<CustomerPaymentMethod>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.PaymentMethodId });

                entity.Property(e => e.CardExpiryDate).HasColumnType("date");

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.CardSecurityNumber).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPaymentMethods)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPaymentMethods_Customer");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.CustomerPaymentMethods)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPaymentMethods_PaymentMethods");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PaymentAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Account");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Customer");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentMethods");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentStatus");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentMethodName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CurrencyExchangeRates>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(18, 4)");
            });
        }
    }
}
