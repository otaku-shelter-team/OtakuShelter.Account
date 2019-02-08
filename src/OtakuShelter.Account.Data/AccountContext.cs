using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	public class AccountContext : DbContext
	{
		public AccountContext(DbContextOptions<AccountContext> options) : base(options)
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