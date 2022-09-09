using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Models.Domain;
using University.Models.DTO;
using University.Repositories;

namespace University.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {

        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var courses = await courseRepository.GetAllAsync();

            //return DTO courses
            //var coursesDTO = new List<Models.DTO.Course>();
            //courses.ToList().ForEach(course =>
            //{
            //var courseDTO = new Models.DTO.Course()
            //{
            //   Id = course.Id,
            //   CourseName = course.CourseName,
            //
            // };

            // coursesDTO.Add(courseDTO);

            //});

           var coursesDTO = mapper.Map<List<Models.DTO.Course>>(courses);

            return Ok(coursesDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetCourseAsync")]
        public async Task<IActionResult> GetCourseAsync(int id)
        {
           var course = await courseRepository.GetAsync(id);

            if(course == null)
            {
                return NotFound();
            }

           var courseDTO = mapper.Map<Models.DTO.Course>(course);




            return Ok(courseDTO);   
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(Models.DTO.AddCourseRequest addCourseRequest)
        {
            //Request(DTo) to Domain Model
            var course = new Models.Domain.Course()
            {

                CourseName = addCourseRequest.CourseName
            };

            //pass details to Reepository
           course= await courseRepository.AddAsync(course);

            //Convert back to DTO
            var courseDTO = new Models.DTO.Course()
            {
                Id = course.Id,
                CourseName = course.CourseName,
            };

            return CreatedAtAction(nameof(GetCourseAsync), new { id = courseDTO.Id }, courseDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            //Get region from the database
           var course = await courseRepository.DeleteAsync(id);


            //if null NotFound
            if(course == null)
            {
                return NotFound();
            }

            //Convert response back to DTO
            var courseDTO = new Models.DTO.Course
            {
                Id = course.Id,
                CourseName = course.CourseName,
            };
            //return Ok Response
            return Ok(courseDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCourseAsync( [FromRoute] int id, [FromBody] Models.DTO.UpdateCourseRequest updateCourseRequest)
        {
            //Convert DTO to Domain model
            var course = new Models.Domain.Course()
            {
                CourseName = updateCourseRequest.CourseName,
            };

            //update Region using Repositry

           course = await courseRepository.UpdateAsync(id, course);   

            //if Null then NotFoound

            if(course == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO

            var courseDTO = new Models.DTO.Course()
            {
                Id = course.Id,
                CourseName = course.CourseName,
            };


            //return response
            return Ok(courseDTO);
        }
    }

}
