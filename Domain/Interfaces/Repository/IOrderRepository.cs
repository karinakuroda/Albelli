using System;
using Domain.Entities;

namespace Domain.Interfaces.Repository
{
	public interface IOrderRepository
    {
		Order Get(Guid orderId);
		
		bool Add(Order order);
		bool Update(Order order);
		bool Remove(Guid orderId);
	}
}
