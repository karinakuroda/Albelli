using System;
using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ICustomerRepository
    {
		Customer Get(Guid customerId);
		
		bool Add(Customer customer);
		bool Update(Customer customer);
		bool Remove(Guid customerId);
	}
}
