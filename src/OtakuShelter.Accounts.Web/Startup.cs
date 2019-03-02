using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Accounts
{
	public class Startup : IStartup
	{
		private readonly AccountsConfiguration configuration;

		public Startup(IOptions<AccountsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddAccountsSwagger()
				.AddAccountsExceptionHandling()
				.AddAccountsMvc(configuration.Roles)
				.AddAccountsDatabase(configuration.Database)
				.AddAccountsRabbitMq(configuration.RabbitMq)
				.AddAccountsAuthentication(configuration.Jwt)
				.AddAccountsHealthChecks(configuration.Database, configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseHealthChecks("/health");
			app.UseAuthentication();
			app.UseReviewsSwagger();
			app.UseMvc();
		}
	}
}