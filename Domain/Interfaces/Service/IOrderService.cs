using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Service
{
	public interface IOrderService
	{
		bool Add(Order order);
		bool Update(Order order);
		bool Remove(Guid orderId);
		Order Get(Guid orderId);

		string Message { get; }
	}
}
