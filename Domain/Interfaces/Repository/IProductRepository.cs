using System;
using Domain.Entities;

namespace Domain.Interfaces.Repository
{
	public interface IProductRepository
    {
		Product Get(Guid productId);
		
		bool Add(Product product);
		bool Update(Product product);
		bool Remove(Guid productId);
	}
}
