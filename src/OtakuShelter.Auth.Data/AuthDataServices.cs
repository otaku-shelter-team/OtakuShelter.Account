using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Auth
{
	public static class AuthDataServices
	{
		public static IServiceCollection AddDataServices(this IServiceCollection services, AuthDatabaseConfiguration database)
		{
			services.AddDbContext<AuthContext>(builder =>
				builder.UseNpgsql(database.ConnectionString, options =>
					options.MigrationsHistoryTable(database.MigrationsTable)));
			
			return services;
		}
	}
}