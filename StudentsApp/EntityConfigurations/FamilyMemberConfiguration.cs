using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsApp.Models;

namespace StudentsApp.EntityConfigurations
{
	public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
	{
		public void Configure(EntityTypeBuilder<FamilyMember> builder)
		{
			builder.ToTable("FamilyMember");

			builder.HasOne(x => x.Nationality)
				.WithMany(x => x.FamilyMembers)
				.HasForeignKey(x => x.NationalityId);
		}
	}
}
