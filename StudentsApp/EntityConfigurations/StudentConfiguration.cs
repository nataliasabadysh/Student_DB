using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsApp.Models;

namespace StudentsApp.EntityConfigurations
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.ToTable("Student");

			builder.HasOne(x => x.Nationality)
				.WithMany(x => x.Students)
				.HasForeignKey(x => x.NationalityId);
		}
	}
}
