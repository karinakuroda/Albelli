using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albelli.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
		private ICustomerService _customerService;

		public CustomerController(ICustomerService customerService) {
			_customerService = customerService;
		}
		// GET api/values
		[HttpGet]
        public Customer Get()
        {
			return _customerService.Get(Guid.NewGuid());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
