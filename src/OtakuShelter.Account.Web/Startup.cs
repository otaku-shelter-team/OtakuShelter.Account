using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Account
{
	public class Startup : IStartup
	{
		private readonly AccountWebConfiguration configuration;

		public Startup(IOptions<AccountWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddDataServices(configuration.Database)
				.AddWebServices(configuration)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseAuthentication();
			
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Account API v1");
				options.DocumentTitle = "OtakuShelter Account API";
				options.DocExpansion(DocExpansion.None);
			});
			
			app.UseMvc();
		}
	}
}