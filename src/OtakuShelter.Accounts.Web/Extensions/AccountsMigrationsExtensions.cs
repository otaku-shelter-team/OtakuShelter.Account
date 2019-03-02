using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Accounts
{
	public static class AccountsMigrationsExtensions
	{
		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<AccountsContext>()
					.Database
					.Migrate();
			}
		}
	}
}