using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private AlbelliContext _context { get; }
		public CustomerRepository(AlbelliContext context)
		{ 
			_context = context;
		}
		 
	 
		public void Add(Customer customer)
		{
			_context.Entry<Customer>(customer);
			_context.SaveChanges();
		}

		public Task<Customer> Get(Guid customerId)
		{
			return  _context.Customers.SingleOrDefaultAsync(s => s.Id == customerId);
		}

		public void Remove(Guid customerId)
		{
			var cust =  Get(customerId);
			 _context.Remove(cust);
			_context.SaveChanges();
		}

		public void Update(Customer customer)
		{
			var old = Get(customer.Id);
			if (old == null) return;
			_context.Entry(old).CurrentValues.SetValues(customer);
			_context.SaveChanges();

		}
	}
}
