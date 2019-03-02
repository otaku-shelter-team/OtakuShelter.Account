using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Accounts
{
	public static class AccountsHealthChecksExtensions
	{
		public static IServiceCollection AddAccountsHealthChecks(
			this IServiceCollection services,
			AccountsDatabaseConfiguration database,
			AccountsRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
		
		public static IApplicationBuilder UseAccountsHealthchecks(this IApplicationBuilder app)
		{
			return app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}