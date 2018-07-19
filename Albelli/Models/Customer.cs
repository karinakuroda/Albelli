using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Customer
    {
		public Guid Id { get; protected set; }
		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }
		public string Email { get; protected set; }
	}
}
