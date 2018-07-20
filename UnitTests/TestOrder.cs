using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;
using Xunit;

namespace UnitTests
{
	[TestClass]
    public class TestOrder
    {
		Mock<IOrderRepository> _mockOrderRepository;
		IOrderService _orderService;

		[TestInitialize]
		public void Init()
		{
			_mockOrderRepository = new Mock<IOrderRepository>();
			_orderService = new OrderService(_mockOrderRepository.Object);
		}

		[TestMethod]
		public void ShouldCallGetOrderOnlyOnce()
        {
			//Arrange
			_mockOrderRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetOrderMock());
			//Act
			var resp = _orderService.Get(It.IsAny<Guid>());
			//Assert
			_mockOrderRepository.Verify(o => o.Get(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldGetOrder()
		{
			//Arrange
			_mockOrderRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetOrderMock());
			//Act
			var resp = _orderService.Get(It.IsAny<Guid>());
			//Assert
			resp.Price.Equals(GetOrderMock().Price);
		}
		[TestMethod]
		public void ShouldCallUpdateOrder()
		{
			//Arrange
			_mockOrderRepository.Setup(s => s.Update(It.IsAny<Order>())).Returns(true);
			//Act
			var resp = _orderService.Update(GetOrderMock());
			//Assert
			_mockOrderRepository.Verify(o => o.Update(It.IsAny<Order>()), Times.Once());
		}

		[TestMethod]
		public void ShouldSumOrderPrice()
		{
			//Arrange
			_mockOrderRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetOrderMock());
			//Act
			var resp = _orderService.Get(It.IsAny<Guid>());
			//Assert
			resp.Price.Equals(GetOrderMock().Products.Sum(p=>p.Quantity * p.Cost));
		}
		private static Order GetOrderMock()
		{

			var list = new List<Product>();
			list.Add(Product.Create(1, 10, "1234"));
			return Order.Create(Customer.Create("Test", "Test@t.com"), list);
		}
	}
}
