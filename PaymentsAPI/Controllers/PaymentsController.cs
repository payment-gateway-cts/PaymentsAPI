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

        [HttpGet]
        public IActionResult GetAllPaymentsList()
        {
            var payments = _paymentService.GetAllPaymentsList();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById([FromRoute]int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment != null)
                return Ok(payment);
            else
                return NotFound();
        }

        public IActionResult MakePayment(Payment newPayment)
        {
            newPayment= _paymentService.MakePayment(newPayment);
            return Ok(newPayment);
        }

        public IActionResult PurgePayments()
        {
            _paymentService.PurgePayments();
            return NoContent();
        }


    }
}