using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.DTO
{
    public class CustomerOrders
    {
		public Guid  Id { get;  set; }
		public  string Name { get; set; }
		public string Email { get; set; }

		public virtual ICollection<Order> Orders { get;  set; }

	}
}
