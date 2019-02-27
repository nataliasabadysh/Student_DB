using AutoMapper;
using StudentsApp.ViewModels;

namespace StudentsApp.Models
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Student, StudentViewModel>();
			CreateMap<StudentViewModel, Student>();
			CreateMap<FamilyMember, FamilyMemberViewModel>();
			CreateMap<FamilyMemberViewModel, FamilyMember>();
		}		
	}
}