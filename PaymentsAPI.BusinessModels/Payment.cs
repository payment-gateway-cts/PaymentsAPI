using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentsAPI.BusinessModels
{
    public class Payment
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Payer { get; set; }
        [Required]
        [MaxLength(50)]
        public string Payee { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [MaxLength(10)]
        public string PayCurrency { get; set; }
        public double USDAmount { get; set; }
    }
}
