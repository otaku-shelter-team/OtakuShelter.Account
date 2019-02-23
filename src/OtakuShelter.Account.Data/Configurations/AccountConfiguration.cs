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

			builder.HasIndex(a => a.Username)
				.IsUnique()
				.HasName("UQ_username");

			builder.Property(a => a.PasswordHash)
				.HasColumnName("passwordhash")
				.HasMaxLength(500)
				.IsRequired();

			builder.Property(a => a.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(a => a.Role)
				.HasColumnName("role")
				.HasMaxLength(25)
				.IsRequired();
		}
	}
}