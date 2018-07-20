using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Albelli.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
		private ICustomerService _customerService;
		private IMapper _mapper;

		public CustomerController(ICustomerService customerService,
								  IMapper mapper) {
			_customerService = customerService;
			_mapper = mapper; 
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
			return Ok(cust);
		}

		// GET api/values/5
		[HttpGet]
		[Route("GetWithOrders")]
		public IActionResult GetWithOrders(Guid id)
		{
			var cust = _customerService.GetWithOrders(id);
			return Ok(cust);
		}


		// GET api/values/5
		[HttpGet]
		[Route("GetAll")]
		public IActionResult GetAll()
		{
			var cust = _customerService.GetAll();
			return Ok(cust);
		}

		[HttpPost]
		public IActionResult Post([FromBody] API.Models.Customer customer)
		{
			try
			{
				bool success = false;
				var model = _mapper.Map<API.Models.Customer, Customer>(customer);
				success = _customerService.Add(model);
				
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
        public IActionResult Put([FromBody]API.Models.Customer customer)
        {
			try
			{
				bool success = false;
				var model = _mapper.Map<API.Models.Customer, Customer>(customer);
				success = _customerService.Update(model);

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
        public IActionResult Delete(Guid id)
        {
			try
			{
				bool success = false;
				success = _customerService.Remove(id);

				if (success)
					return Ok(_customerService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Delete Customer"));
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException(ex.ToString()));
			}
		}
    }
}
