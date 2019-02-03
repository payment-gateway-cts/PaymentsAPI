using System;

namespace PaymentsAPI.BusinessModels
{
    public class AccountBM
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Currency { get; set; }
        public string IBAN { get; set; }
        public decimal? CurrentBalance { get; set; }
    }
}
