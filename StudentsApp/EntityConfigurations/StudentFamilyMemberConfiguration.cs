using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsApp.Models;

namespace StudentsApp.EntityConfigurations
{
	public class StudentFamilyMemberConfiguration : IEntityTypeConfiguration<StudentFamilyMember>
	{
		public void Configure(EntityTypeBuilder<StudentFamilyMember> builder)
		{
			builder.ToTable("StudentFamilyMember");

			builder.HasKey(x => new { x.StudentId, x.FamilyMemberId });

			builder.HasOne(x => x.Student)
				.WithMany(x => x.StudentFamilyMembers)
				.HasForeignKey(x => x.StudentId);

			builder.HasOne(x => x.FamilyMember)
				.WithMany(x => x.StudentFamilyMembers)
				.HasForeignKey(x => x.FamilyMemberId);
		}
	}
}