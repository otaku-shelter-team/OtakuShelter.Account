using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Account
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.ToTable("accounts");
			
			builder.Property(i => i.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(i => i.Username)
				.HasColumnName("username")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(i => i.PasswordHash)
				.HasColumnName("passwordhash")
				.HasMaxLength(500)
				.IsRequired();
		}
	}
}