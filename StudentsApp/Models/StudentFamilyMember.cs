namespace StudentsApp.Models
{
	public class StudentFamilyMember
	{
		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int FamilyMemberId { get; set; }
		public virtual FamilyMember FamilyMember { get; set; }
	}
}
