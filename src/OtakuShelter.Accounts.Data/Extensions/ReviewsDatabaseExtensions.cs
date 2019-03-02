using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Accounts
{
	public static class AccountsDatabaseExtensions
	{
		public static IServiceCollection AddAccountsDatabase(
			this IServiceCollection services,
			AccountsDatabaseConfiguration configuration)
		{
			services.AddDbContextPool<AccountsContext>(options =>
				options.UseNpgsql(configuration.ConnectionString, builder =>
						builder.MigrationsHistoryTable(configuration.MigrationsTable))
					.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning)));

			return services;
		}
	}
}