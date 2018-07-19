using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Service
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository _customerRepository;
		public string Message { get; private set; }

		public CustomerService(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}
		

		public void Add(Customer customer)
		{
			 _customerRepository.Add(customer);
		}

		public Task<Customer> Get(Guid customerId)
		{
			return _customerRepository.Get(customerId);
		}

		public void Remove(Guid customerId)
		{
			 _customerRepository.Remove(customerId);
		}

		public void Update(Customer customer)
		{
			_customerRepository.Update(customer);
		}
	}
}
