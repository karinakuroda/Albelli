using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Service
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}
		

		public void Add(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Customer Get(Guid customerId)
		{
			return _customerRepository.Get(customerId);
		}

		public void Remove(Guid customerId)
		{
			throw new NotImplementedException();
		}

		public void Update(Customer customer)
		{
			throw new NotImplementedException();
		}
	}
}
