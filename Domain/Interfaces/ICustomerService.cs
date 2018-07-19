using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ICustomerService
	{
		void Add(Customer customer);
		void Update(Customer customer);
		void Remove(Guid customerId);
		Task<Customer> Get(Guid customerId);

		string Message { get; }
	}
}
