using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Product:Entity 
	{
		public virtual Guid Id { get; protected set; }

		public virtual int Quantity { get; protected set; } 
		public virtual decimal Cost { get; protected set; }
		public virtual string Code { get; protected set; }

		public Order Order { get; protected set; }



		private static Product Create(Guid id, int quantity, decimal cost, string code)
		{
			var product = new Product();
			if (quantity<=0) product.AddValidation("Quantity can't be empty");
			if (string.IsNullOrEmpty(code)) product.AddValidation("Code can't be empty");
			if (cost<=0) product.AddValidation("Cost can't be empty");
			//if (order==null) product.AddValidation("Order can't be null");
			
			product.Id = id;
			product.Quantity = quantity;
			product.Cost = cost;
			product.Code= code;

			return product;
		}

		public static Product Create(int quantity, decimal cost, string code)
		{
			return Create(Guid.NewGuid(), quantity, cost, code);
		}
	}
}
