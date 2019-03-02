using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Accounts
{
	internal class TokenConfiguration : IEntityTypeConfiguration<Token>
	{
		public void Configure(EntityTypeBuilder<Token> builder)
		{
			builder.ToTable("tokens");

			builder.Property(s => s.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(s => s.IpAddress)
				.HasColumnName("ip_address")
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(s => s.RefreshToken)
				.HasColumnName("refresh")
				.HasMaxLength(500)
				.IsRequired();

			builder.Property(s => s.UserAgent)
				.HasColumnName("useragent")
				.HasMaxLength(200);
			
			builder.Property(s => s.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(s => s.AccountId)
				.HasColumnName("account_id");

			builder.HasOne(s => s.Account)
				.WithMany(a => a.Tokens)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_account_tokens");
		}
	}
}