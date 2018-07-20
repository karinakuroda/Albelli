using System;
using System.Linq;
using System.Reflection;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Infra.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private AlbelliContext _context { get; }
		public OrderRepository(AlbelliContext context)
		{ 
			_context = context;
		}
		 
	 
		public bool Add(Order order)
		{

			_context.Add(order);
			_context.Entry<Customer>(order.Customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

			var result = _context.SaveChanges();
			return result > 0;
		}

		public Order Get(Guid orderId)
		{
			return  _context.Orders.FirstOrDefault(s => s.Id == orderId);
		}

		public bool Remove(Guid orderId)
		{
			var cust =  Get(orderId);
			 _context.Remove(cust);
			return (_context.SaveChanges()>0);
		}

		public bool Update(Order order)
		{
			var old = Get(order.Id);
			if (old == null) return false;
			_context.Entry(old).CurrentValues.SetValues(order);
			_context.Entry<Customer>(order.Customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
			
			return (_context.SaveChanges() > 0);

		}
	}
}
