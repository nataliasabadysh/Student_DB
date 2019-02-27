using StudentsApp.ViewModels;
using System;
using System.Collections.Generic;

namespace StudentsApp.Models
{
	public class Student
	{
		public int StudentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateBirth { get; set; }
		public int NationalityId { get; set; }
		public virtual Nationality Nationality { get; set; }
		public virtual List<StudentFamilyMember> StudentFamilyMembers { get; set; }
	}
}