using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Service
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository _customerRepository;
		public List<string> Message { get; private set; }

		public CustomerService(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}
		

		public bool Add(Customer customer)
		{
			var model = Customer.Validate(customer);
			if (model.Validations==null ||  model.Validations.ToArray().Length == 0)
				return _customerRepository.Add(customer);
			else
				this.Message = model.Validations;

			return false;

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
