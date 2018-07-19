using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order:Entity
    {
		public virtual Guid Id { get; protected set; }
		public virtual decimal Price { get; protected set; }
	

		public virtual Customer Customer { get; protected set; }

		public virtual ICollection<Product> Products { get; protected set; }

		public static Order Create(Customer customer, decimal price, List<Product> products)
		{
			var order = new Order();

			if (customer == null) customer.AddValidation("Customer object can't be null");
			if (price<=0) customer.AddValidation("Price can't be empty");

			order.Customer = customer;
			order.Price = price;
			order.Products = products;
			
			
			return order;
		}

	}
}
