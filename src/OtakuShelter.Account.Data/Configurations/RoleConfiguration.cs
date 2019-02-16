using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Account
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("roles");

			builder.Property(r => r.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(r => r.Name)
				.HasColumnName("name")
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(r => r.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(r => r.CreatorId)
				.HasColumnName("creatorid");

			builder.HasOne(r => r.Creator)
				.WithMany(a => a.Roles)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_creator_roles");
		}
	}
}