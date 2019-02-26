using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Account
{
	public static class AccountHealthServices
	{
		public static IServiceCollection AddHealthServices(
			this IServiceCollection services,
			AccountContextConfiguration database)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString);
			
			return services;
		}
	}
}