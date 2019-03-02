using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	public class AccountsContext : DbContext
	{
		public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
		{
		}
		
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Token> Tokens { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AccountConfiguration());
			modelBuilder.ApplyConfiguration(new TokenConfiguration());
		}
	}
}