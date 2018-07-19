using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
		//// GET api/values
		//[HttpGet]
  //      public Customer Get()
  //      {
		//	return _customerService.Get(Guid.NewGuid());
  //      }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
			var cust =  _customerService.Get(id);
			return Ok(cust.Result);
		}


		[HttpPost]
		public IActionResult Post([FromBody] API.Models.Customer customer)
		{
			try
			{
				bool success = false;
				var cust = Customer.Create(customer.FirstName, customer.LastName, customer.Email);
				_customerService.Add(cust);
				
				if (success)
					return Ok(_customerService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Save Customer"));
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException(ex.ToString()));
			}
		}
		// PUT api/values/5
		[HttpPut]
        public IActionResult Put( [FromBody]API.Models.Customer customer)
        {
			
			try
			{
				bool success = false;
				var cust = Customer.Create(customer.Id, customer.FirstName, customer.LastName, customer.Email);
				_customerService.Update(cust);

				if (success)
					return Ok(_customerService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Update Customer"));
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException(ex.ToString()));
			}

		}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
			_customerService.Remove(id);
        }
    }
}
