using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Service
{
	public interface ICustomerService
	{
		bool Add(Customer customer);
		bool Update(Customer customer);
		bool Remove(Guid customerId);
		Customer Get(Guid customerId);
		List<Customer> GetAll();

		List<string> Message { get; }
	}
}
