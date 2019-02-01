using System;
using System.Collections.Generic;

namespace PaymentsAPI.DataModel.Entities
{
    public partial class CurrencyExchangeRates
    {
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
