using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Interfaces;
using PaymentsAPI.BusinessModels;

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;

        public PaymentsController(IPaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PaymentBM> Get()
        {
            return _paymentService.GetPayments();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(PaymentBM value)
        {
            //ToDo: Clean-up
            //if(value == null)
            //{
            //    value = new PaymentBM
            //    {
            //        //payee gets payment from payor
            //        PayeeAccountNumber = "70872490",
            //        PayeeCurrency = PaymentEnums.Currency.GBP.ToString(),

            //        //payor pay to payee
            //        PayorAccountNumber = "35933158286",
            //        PayorCurrency = PaymentEnums.Currency.INR.ToString(),

            //        PaymentMethod = PaymentEnums.PaymentMethod.InternateBanking.ToString(),
            //        Amount = 10000,                    
            //        PaymentDate = DateTime.Now.ToString(),
            //        TransactionType = PaymentEnums.TransactionType.Credit.ToString()
            //    };
            //}
            if (value != null)
            {
                if (string.IsNullOrEmpty(value.PayeeCurrency)) value.PayeeCurrency = PaymentEnums.Currency.GBP.ToString();
                if (string.IsNullOrEmpty(value.PayorCurrency)) value.PayorCurrency = PaymentEnums.Currency.INR.ToString();

                value.Amount = value.Amount * _paymentService.GetCurrencyExchangeRate(value.PayorCurrency, value.PayeeCurrency);
                value.PaymentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (string.IsNullOrEmpty(value.PaymentMethod)) value.PaymentMethod = PaymentEnums.PaymentMethod.InternateBanking.ToString();


            }
            _paymentService.MakePayment(value);
        }

    }
}