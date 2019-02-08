using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Account
{
	public class TokenConfiguration : IEntityTypeConfiguration<Token>
	{
		public void Configure(EntityTypeBuilder<Token> builder)
		{
			builder.ToTable("tokens");

			builder.Property(s => s.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(s => s.IpAddress)
				.HasColumnName("ipaddress")
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(s => s.RefreshToken)
				.HasColumnName("refresh")
				.HasMaxLength(500)
				.IsRequired();

			builder.Property(s => s.UserAgent)
				.HasColumnName("useragent")
				.HasMaxLength(100);
			
			builder.Property(s => s.DateTime)
				.HasColumnName("datetime")
				.IsRequired();

			builder.Property(s => s.AccountId)
				.HasColumnName("accountid")
				.IsRequired();

			builder.HasOne(s => s.Account)
				.WithMany(a => a.Tokens)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_account_sessions");
		}
	}
}