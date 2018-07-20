using System;
using System.Linq;
using System.Reflection;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private AlbelliContext _context { get; }
		public IProductRepository _productRepository { get; }
		public ICustomerRepository _customerRepository { get; }

		public OrderRepository(AlbelliContext context, IProductRepository productRepository, ICustomerRepository customerRepository)
		{ 
			_context = context;
			_productRepository = productRepository;
			_customerRepository = customerRepository;
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
			var order=  _context.Orders
				.Include(i=>i.Customer)
				.Include(i => i.Products)
				.FirstOrDefault(s => s.Id == orderId);
			return order;
			
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
			
			foreach (var product in order.Products)
			{
				if (product.Id == Guid.Empty)
					_context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Added;
				else
					_context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		
			return (_context.SaveChanges() > 0);

		}
	}
}
