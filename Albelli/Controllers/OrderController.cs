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
    public class OrderController : Controller
    {
		private IOrderService _orderService;
		private IMapper _mapper; 

		public OrderController(IOrderService orderService,
							   IMapper mapper) {
			_orderService = orderService;
			_mapper = mapper; 
		}
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
			var cust =  _orderService.Get(id);
			return Ok(cust);
		}


		[HttpPost]
		public IActionResult Post([FromBody] API.Models.Order order)
		{
			try
			{
				bool success = false;
				var model = _mapper.Map<API.Models.Order, Order>(order);
				success = _orderService.Add(model);
				
				if (success)
					return Ok(_orderService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Save Order"));
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException(ex.ToString()));
			}
		}
		// PUT api/values/5
		[HttpPut]
		public IActionResult Put([FromBody]API.Models.Order order)
		{

			try
			{
				bool success = false;
				var model = _mapper.Map<API.Models.Order, Order>(order);
				success = _orderService.Update(model);

				if (success)
					return Ok(_orderService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Update Order"));
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
				success = _orderService.Remove(id);

				if (success)
					return Ok(_orderService.Message);
				else
					return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException("Can't Delete Order"));
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, new System.ApplicationException(ex.ToString()));
			}
		}
	}
}
