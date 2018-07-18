using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ICustomerService
	{
		void Add(Customer customer);
		void Update(Customer customer);
		void Remove(Guid customerId);
		Customer Get(Guid customerId);
	}
}
