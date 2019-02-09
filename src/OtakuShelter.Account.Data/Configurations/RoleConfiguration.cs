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

			builder.HasData(new Role { Id = 1, Name = "user"}, new Role {Id = 2, Name = "admin"});
		}
	}
}