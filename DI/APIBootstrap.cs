using System;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infra;
using Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace DI
{
	public class APIBootstrap
	{


		public static void ConfigureServices(ref IServiceCollection services)
		{
			var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false)
															  .AddJsonFile("appsettings.Development.json", optional: true)
															  .Build();


			services.AddTransient<ICustomerService, CustomerService>();
			services.AddTransient<IOrderService, OrderService>(); 

			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();

			services.AddTransient<AlbelliContext, AlbelliContext>();



		}
	}
}
