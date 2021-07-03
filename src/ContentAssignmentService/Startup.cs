using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Neo4j.Driver;
using System;

namespace ContentAssignmentService
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
			services.AddSingleton(GetDriver);

			services.AddControllers();
		}

		private IDriver GetDriver(IServiceProvider provider)
		{
			//We're creating a logger here that the IDriver can use, that also hooks into the ASPNET logger
			var logger = new Neo4JAspNetCoreLogger(provider.GetService<ILogger<IDriver>>())
			{
				//LogLevel is pulled from the ASP NET default logging level
				Level = Enum.Parse<LogLevel>(Configuration["Logging:LogLevel:Default"])
			};

			//Setup our IDriver instance to be injected 
			var driver = GraphDatabase.Driver(
				Configuration["Neo4j:Host"],
				AuthTokens.Basic(
					Configuration["Neo4j:User"],
					Configuration["Neo4j:Pass"]),
				config => config.WithLogger(logger)
			);
			return driver;
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
