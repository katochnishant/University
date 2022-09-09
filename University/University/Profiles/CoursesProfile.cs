using AutoMapper;

namespace University.Profiles
{
    public class CoursesProfile: Profile

    {
        public CoursesProfile()
        {
            CreateMap<Models.Domain.Course,Models.DTO.Course>()
                .ReverseMap();  
        }
    }
}
