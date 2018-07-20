using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repository
{
	public interface ICustomerRepository
    {
		Customer Get(Guid customerId);
		List<Customer> GetAll();
		bool Add(Customer customer);
		bool Update(Customer customer);
		bool Remove(Guid customerId);
	}
}
