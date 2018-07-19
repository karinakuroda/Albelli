using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
		public virtual Guid Id { get; protected set; }

		public virtual int Quantity { get; protected set; }
		[Column(TypeName = "decimal(18, 2)")]
		public virtual decimal Cost { get; protected set; }
		public virtual string Code { get; protected set; }

		public Order Order { get; protected set; }
	}
}
