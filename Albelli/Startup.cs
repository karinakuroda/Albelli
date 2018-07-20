using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Mappings;
using AutoMapper;
using DI;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Albelli
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			APIBootstrap.ConfigureServices(ref services);
			services.AddMvc()
			 .AddJsonOptions(options =>
			  {
				  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			  });
			services.AddAutoMapper();
			//AutoMapperConfig.RegisterMappings();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Albelli API", Version = "v1" });
			});


			var connection = @"Server=(localdb)\mssqllocaldb;Database=Albelli;Trusted_Connection=True;";
			services.AddDbContext<AlbelliContext>(options => options.UseSqlServer(connection));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Albelli API");
				c.RoutePrefix = string.Empty;
			});

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
