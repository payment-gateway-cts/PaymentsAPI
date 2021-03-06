﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Interfaces;

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;

        public CustomersController(IPaymentsService  paymentService)
        {
            _paymentService = paymentService;
        }

        // GET api/customers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_paymentService.GetCustomers());
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
