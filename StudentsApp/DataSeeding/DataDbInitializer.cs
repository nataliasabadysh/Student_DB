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
					new Nationality(){ NationalityId = 1001, Title = "UAE"},
					new Nationality(){ NationalityId = 1002, Title = "India"},
                    new Nationality(){ NationalityId = 1002, Title = "UK"},

                };
				var students = new List<Student>()
				{
					new Student() {StudentId = 2001, FirstName = "Jon", LastName = "Legend", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1001},
					new Student() {StudentId = 2002, FirstName = "Bob", LastName = "Ross", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1001},
					new Student() {StudentId = 2003, FirstName = "Bradley", LastName = "Cooper", DateBirth = new DateTime(1970, 1, 1), NationalityId = 1002},
				};

				context.Nationalities.AddRange(nationality);
				context.Students.AddRange(students);
				context.SaveChanges();
			}

		}
	}
}
