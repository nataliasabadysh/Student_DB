using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsApp.Models;

namespace StudentsApp.EntityConfigurations
{
	public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
	{
		public void Configure(EntityTypeBuilder<Nationality> builder)
		{
			builder.ToTable("Nationality");
		}
	}
}