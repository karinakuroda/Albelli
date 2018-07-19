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
		

		public bool Add(Customer customer)
		{
			 return _customerRepository.Add(customer);
		}

		public Customer Get(Guid customerId)
		{
			return _customerRepository.Get(customerId);
		}

		public bool Remove(Guid customerId)
		{
			 return _customerRepository.Remove(customerId);
		}

		public bool Update(Customer customer)
		{
			return _customerRepository.Update(customer);
		}
	}
}
