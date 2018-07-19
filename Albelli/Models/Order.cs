using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
		public Guid Id { get;  set; }
		public decimal Price { get;  set; }
		public Customer Customer { get;  set; }
		public ICollection<Product> Products { get;  set; }
	}
}
