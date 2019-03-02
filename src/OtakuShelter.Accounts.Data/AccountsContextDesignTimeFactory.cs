using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Accounts
{
	public class AccountsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AccountsContext>
	{
		public AccountsContext CreateDbContext(string[] args)
		{
			return new ServiceCollection()
				.AddAccountsDatabase(new AccountsDatabaseConfiguration())
				.BuildServiceProvider()
				.GetRequiredService<AccountsContext>();
		}
	}
}