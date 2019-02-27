using System.Collections.Generic;

namespace StudentsApp.Models
{
	public class Nationality
	{
		public int NationalityId { get; set; }
		public string Title { get; set; }
		public virtual List<Student> Students { get; set; }
		public virtual List<FamilyMember> FamilyMembers { get; set; }
	}
}
