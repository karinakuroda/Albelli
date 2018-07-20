using System;
using System.Collections.Generic;
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
		public List<string> Message { get; private set; }

		public OrderService(IOrderRepository orderRepository) {
			_orderRepository = orderRepository;
		}

		public bool Add(Order order)
		{
			var model = Order.Validate(order);
			if (model.Validations == null ||  model.Validations.ToArray().Length == 0)
				return _orderRepository.Add(order);
			else
				this.Message = model.Validations;

			return false;
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
			foreach (var product in order.Products)
			{
				product.UpdateOrder(order);
			}

			return _orderRepository.Update(order);
		}
	}
}
