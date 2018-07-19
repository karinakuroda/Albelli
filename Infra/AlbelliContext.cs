using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class AlbelliContext: DbContext
	{
		public AlbelliContext(DbContextOptions<AlbelliContext> options)
		  : base(options)
		{ }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>(o =>
			{
				o.Property(b => b.Price).HasColumnType("decimal(10, 2)");
			});

			modelBuilder.Entity<Product>(p =>
			{
				p.Property(b => b.Cost).HasColumnType("decimal(10, 2)");
			});

		}
	}

}
