using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Auth
{
	public class IdentityConfiguration : IEntityTypeConfiguration<Identity>
	{
		public void Configure(EntityTypeBuilder<Identity> builder)
		{
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