using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Order:Entity
    {
		public virtual Guid Id { get; protected set; }
		

		private decimal _price;
		
		public virtual decimal Price
		{
			get
			{
				return Products!= null? Products.Sum(p=>p.Cost*p.Quantity) : 0;
			}
			set
			{
				_price = value;
			}
		}



		public virtual Customer Customer { get; protected set; }
		public virtual ICollection<Product> Products { get; protected set; }

		public static Order Validate(Order order)
		{
			var model = Order.Create(order.Id, order.Customer, order.Products.ToList());
			return model;
		}
		public static Order Create(Customer customer, List<Product> products)
		{ 
			var order = Order.Create(Guid.NewGuid(), customer, products);
			return order;
		}

		private static Order Create(Guid id, Customer customer, List<Product> products)
		{

			var order = new Order();

			if (customer == null) order.AddValidation("Customer object can't be null");

			order.Id = id;
			order.Customer = customer;
			order.Products = products;
			return order;
		}

	}
}
