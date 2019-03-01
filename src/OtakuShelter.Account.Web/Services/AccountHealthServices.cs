using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Account
{
	public static class AccountHealthServices
	{
		public static IServiceCollection AddHealthServices(
			this IServiceCollection services,
			AccountContextConfiguration database,
			AccountRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
	}
}