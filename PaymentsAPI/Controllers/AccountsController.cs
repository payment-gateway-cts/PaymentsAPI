using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Interfaces;

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;

        public AccountsController(IPaymentsService  paymentService)
        {
            _paymentService = paymentService;
        }

        // GET api/accounts
        [HttpGet]
        public JsonResult Get()
        {
            //return new JsonResult(_paymentService.GetAccounts());
            return new JsonResult("To Do");
        }

        // GET api/accounts/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult("Account");
        }

        // POST api/accounts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/accounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
