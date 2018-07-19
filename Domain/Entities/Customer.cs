using System;

namespace Domain.Entities
{
    public class Customer: Entity
	{
		public virtual Guid Id { get; protected set; }
		public virtual string Name { get; protected set; }
		public virtual string Email { get; protected set; }


		public static Customer Create(string name, string email)
		{
			return Create(Guid.NewGuid(), name, email) ;
		}

		public static Customer Create(string firstName, string lastName, string email)
		{
			return Create(Guid.NewGuid(), string.Format("{0} {1}",firstName, lastName), email);
		}
		public static Customer Create(Guid id, string firstName, string lastName, string email)
		{
			return Create(id, string.Format("{0} {1}", firstName, lastName), email);
		}
		private static Customer Create(Guid id, string name, string email)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name is empty");
			
			if (string.IsNullOrEmpty(email))
				throw new ArgumentNullException("email is empty");
			
			Customer customer = new Customer()
			{
				Id = id,
				Name=name,
				Email = email
			};
 
			return customer;
		}
	}
}
