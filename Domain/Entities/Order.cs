using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
		public virtual Guid Id { get; protected set; }
		public virtual decimal Price { get; protected set; }
		public virtual DateTime Created { get; protected set; }

		public virtual Customer Customer { get; protected set; }

		public virtual ICollection<Product> Products { get; protected set; }

		public static Order Create(Customer customer, decimal price)
		{
			if (customer == null)
				throw new Exception("Customer object can't be null");

			if (price<=0)
				throw new Exception("Price can't be empty");

		
			Order order = new Order
			{
				Customer = customer,
				Price = price,
				Created = DateTime.Today
			};
			
			return order;
		}

	}
}
