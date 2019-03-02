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
	}
}