using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repository
{
	public interface IOrderRepository
    {
		Order Get(Guid orderId);
		List<Order> GetByCustomer(Guid customerId);
		bool Add(Order order);
		bool Update(Order order);
		bool Remove(Guid orderId);


	}
}
