using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		public Customer Get(Guid customerId)
		{
			return Customer.Create("teste","t@t.com");
		}
	}
}
