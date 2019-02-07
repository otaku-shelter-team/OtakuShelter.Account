using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Auth
{
	public class AuthContext : DbContext
	{
		public AuthContext()
		{
		}

		public AuthContext(DbContextOptions<AuthContext> options) : base(options)
		{
		}
		
		public DbSet<Identity> Identities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new IdentityConfiguration());
		}
	}
}