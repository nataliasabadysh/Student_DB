using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Models;
using StudentsApp.ViewModels;

namespace StudentsApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		protected StudentAppContext DbContext { get; }
		public StudentsController(StudentAppContext dbContext)
		{
			DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var students = DbContext
				.Students
				.Include(x => x.StudentFamilyMembers)
					.ThenInclude(x => x.FamilyMember)
				.Include(x => x.Nationality)
				.ToList();

			return Ok(students);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]StudentViewModel model)
		{
			try
			{
				var newStudent = new Student();
				Mapper.Map(model, newStudent);
				DbContext.Students.Add(newStudent);
				DbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpPut("{studentId}")]
		public async Task<IActionResult> Put(int studentId, [FromBody]StudentViewModel model)
		{
			try
			{
				var student = DbContext.Students.FirstOrDefault(x => x.StudentId == studentId);
				if (student != null)
				{
					student.FirstName = model.FirstName;
					student.LastName = model.LastName;
					student.NationalityId = model.NationalityId;

					DbContext.Students.Update(student);
					DbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpGet("{studentId}/Nationality")]
		public async Task<IActionResult> GetNationality(int studentId, int nationalityId)
		{
			try
			{
				var student = DbContext.Students.Where(x => x.StudentId == studentId).Include(x => x.Nationality).FirstOrDefault();
				if (student != null)
				{
					return Ok(student.Nationality);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpPut("{studentId}/Nationality/{nationalityId}")]
		public async Task<IActionResult> PutNationality(int studentId, int nationalityId)
		{
			try
			{
				var student = DbContext.Students.FirstOrDefault(x => x.StudentId == studentId);
				if (student != null)
				{
					student.NationalityId = nationalityId;
					DbContext.Students.Update(student);
					DbContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpGet("{studentId}/FamilyMembers")]
		public async Task<IActionResult> GetFamilyMembers(int studentId)
		{
			try
			{
				var student = DbContext.Students.Where(x => x.StudentId == studentId).Include(x => x.StudentFamilyMembers).ThenInclude(x => x.FamilyMember).FirstOrDefault();
				if (student != null)
				{
					return Ok(student.StudentFamilyMembers.Select(x => x.FamilyMember).ToList());
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpPost("{studentId}/FamilyMembers")]
		public async Task<IActionResult> PostFamilyMembers(int studentId, [FromBody]FamilyMemberViewModel model)
		{
			try
			{
				var newFamilyMember = new FamilyMember();
				Mapper.Map(model, newFamilyMember);
				DbContext.FamilyMembers.Add(newFamilyMember);
				DbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}
	}
}