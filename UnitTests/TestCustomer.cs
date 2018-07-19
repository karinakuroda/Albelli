using System;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;
using Xunit;

namespace UnitTests
{
	[TestClass]
    public class TestCustomer
    {
		Mock<ICustomerRepository> _mockCustomerRepository;
		ICustomerService _customerService;

		[TestInitialize]
		public void Init()
		{
			_mockCustomerRepository = new Mock<ICustomerRepository>();
			_customerService = new CustomerService(_mockCustomerRepository.Object);
		}

		[TestMethod]
		public void ShouldCallGetCustomerOnlyOnce()
        {
			//Arrange
			_mockCustomerRepository.Setup(s => s.Get(It.IsAny<Guid>())).ReturnsAsync(GetCustomerMock());
			//Act
			var resp = _customerService.Get(It.IsAny<Guid>());
			//Assert
			_mockCustomerRepository.Verify(o => o.Get(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldGetCustomer()
		{
			//Arrange
			_mockCustomerRepository.Setup(s => s.Get(It.IsAny<Guid>())).ReturnsAsync(GetCustomerMock());
			//Act
			var resp = _customerService.Get(It.IsAny<Guid>());
			//Assert
			resp.Result.Email.Equals(GetCustomerMock().Email);
		}
		private static Customer GetCustomerMock()
		{
			return Customer.Create("Test", "Test@t.com");
		}
	}
}
