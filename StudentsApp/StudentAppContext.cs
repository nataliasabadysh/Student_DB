using Microsoft.EntityFrameworkCore;
using StudentsApp.EntityConfigurations;
using StudentsApp.Models;

namespace StudentsApp
{
	public class StudentAppContext : DbContext
	{
		public StudentAppContext(DbContextOptions<StudentAppContext> options)
			: base(options)
		{ }
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
		public virtual DbSet<Nationality> Nationalities { get; set; }
		public virtual DbSet<StudentFamilyMember> StudentFamilyMembers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StudentConfiguration());
			modelBuilder.ApplyConfiguration(new NationalityConfiguration());
			modelBuilder.ApplyConfiguration(new FamilyMemberConfiguration());
			modelBuilder.ApplyConfiguration(new StudentFamilyMemberConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
