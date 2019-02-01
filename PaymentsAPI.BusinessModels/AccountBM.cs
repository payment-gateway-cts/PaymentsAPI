using System;

namespace PaymentsAPI.BusinessModels
{
    public class AccountBM
    {
        public string Id { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Product { get; set; }
        public string AccountType { get; set; }
        public string BIC { get; set; }
    }
}
