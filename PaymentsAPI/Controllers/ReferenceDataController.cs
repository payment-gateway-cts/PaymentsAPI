using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Interfaces;

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;

        public ReferenceDataController(IPaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET api/ReferenceData
        [HttpGet("PaymentMethods")]
        public IActionResult GetPaymentMethods()
        {
            return Ok(_paymentService.GetPaymentMethods());
        }

        // GET api/ReferenceData
        [HttpGet("AccountTypes")]
        public IActionResult GetAccountTypes()
        {
            return Ok(_paymentService.GetAccountTypes());
        }

    }
}