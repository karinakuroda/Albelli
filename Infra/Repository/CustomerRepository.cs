using System;
using System.Linq;
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
		 
	 
		public bool Add(Customer customer)
		{
			_context.Add(customer);
			var result = _context.SaveChanges();
			return result > 0;
		}

		public Customer Get(Guid customerId)
		{
			return  _context.Customers.FirstOrDefault(s => s.Id == customerId);
		}

		public bool Remove(Guid customerId)
		{
			var cust =  Get(customerId);
			 _context.Remove(cust);
			return (_context.SaveChanges()>0);
		}

		public bool Update(Customer customer)
		{
			var old = Get(customer.Id);
			if (old == null) return false;
			_context.Entry(old).CurrentValues.SetValues(customer);
			return (_context.SaveChanges() > 0);

		}
	}
}
