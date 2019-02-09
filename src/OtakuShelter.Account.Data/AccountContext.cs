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
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AccountConfiguration());
			modelBuilder.ApplyConfiguration(new TokenConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}
	}
}