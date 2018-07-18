using System;
using Domain.Interfaces;
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


			services.AddSingleton<ICustomerService, CustomerService>();


		}
	}
}
