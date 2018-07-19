using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Service
{
	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;
		public string Message { get; private set; }

		public OrderService(IOrderRepository orderRepository) {
			_orderRepository = orderRepository;
		}
		

		public bool Add(Order order)
		{
			 return _orderRepository.Add(order);
		}

		public Order Get(Guid orderId)
		{
			return _orderRepository.Get(orderId);
		}

		public bool Remove(Guid orderId)
		{
			 return _orderRepository.Remove(orderId);
		}

		public bool Update(Order order)
		{
			return _orderRepository.Update(order);
		}
	}
}
