using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsApp.DataSeeding
{
	public static class DataDbInitializer
	{
		public static void Seed(StudentAppContext context)
		{
			if (!context.Students.Any())
			{
				var nationality = new List<Nationality>()
				{
					new Nationality(){ NationalityId = 1001, Title = "Ukraine"},
					new Nationality(){ NationalityId = 1002, Title = "England"},

				};
				var students = new List<Student>()
				{
					new Student() {StudentId = 2001, FirstName = "Anton", LastName = "Antonov", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1001},
					new Student() {StudentId = 2002, FirstName = "Sergey", LastName = "Sergeev", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1001},
					new Student() {StudentId = 2003, FirstName = "Kirill", LastName = "Kirillov", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1002},
				};

				context.Nationalities.AddRange(nationality);
				context.Students.AddRange(students);
				context.SaveChanges();
			}

		}
	}
}
