using University.Models.Domain;

namespace University.Repositories
{
    public interface ICourseRepository
    {
       Task< IEnumerable<Course>> GetAllAsync();

        Task<Course> GetAsync(int id);

        Task<Course> AddAsync(Course course);

       Task<Course> DeleteAsync(int id);

        Task<Course> UpdateAsync(int id, Course course);
    }
}
