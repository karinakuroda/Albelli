using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Entity
    {
		public virtual DateTime Created { get; protected set; }
	}
}
