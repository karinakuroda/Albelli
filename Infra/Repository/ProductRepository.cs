using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Infra.Repository
{
	public class ProductRepository : IProductRepository
	{
		private AlbelliContext _context { get; }
		public ProductRepository(AlbelliContext context)
		{ 
			_context = context;
		}
		 
	 
		public bool Add(Product product)
		{
			_context.Add(product);
			_context.Entry(product.Order).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
			var result = _context.SaveChanges();
			return result > 0;
		}

		public Product Get(Guid productId)
		{
			return  _context.Products.FirstOrDefault(s => s.Id == productId);
		}

		public bool Remove(Guid productId)
		{
			var cust =  Get(productId);
			 _context.Remove(cust);
			return (_context.SaveChanges()>0);
		}

		public bool Update(Product product)
		{
			var old = Get(product.Id);
			if (old == null) return false;
			_context.Entry(old).CurrentValues.SetValues(product);
			_context.Entry(product.Order).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
			return (_context.SaveChanges() > 0);

		}
	}
}
