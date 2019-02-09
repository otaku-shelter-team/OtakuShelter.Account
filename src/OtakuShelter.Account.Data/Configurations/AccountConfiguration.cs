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

			builder.Property(a => a.PasswordHash)
				.HasColumnName("passwordhash")
				.HasMaxLength(500)
				.IsRequired();

			builder.Property(a => a.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(a => a.RoleId)
				.HasColumnName("roleid")
				.IsRequired();

			builder.HasOne(a => a.Role)
				.WithMany(r => r.Accounts)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_role_accounts");
		}
	}
}