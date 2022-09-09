using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models.Domain;

namespace University.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext universityDbContext;
        
        public CourseRepository(UniversityDbContext universityDbContext)
        {
            this.universityDbContext = universityDbContext;
        }

        public async Task<Course> AddAsync(Course course)
        {
            course.Id = new int();
            await universityDbContext.AddAsync(course); 
            await universityDbContext.SaveChangesAsync();   
            return course;
        }

        public async Task<Course> DeleteAsync(int id)
        {
            var course = await universityDbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if(course == null)
            {
                return null;
            }

            //Delete the Course
            universityDbContext.Courses.Remove(course);
            await universityDbContext.SaveChangesAsync();
            return course;

        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
           return await universityDbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            return await  universityDbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Course> UpdateAsync(int id, Course course)
        {
          var existingCourse = await  universityDbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
          
            if(course == null)
            {
                return null;

            }
         existingCourse.CourseName = course.CourseName;

            universityDbContext.SaveChangesAsync();

            return existingCourse;
        }
    }


}
