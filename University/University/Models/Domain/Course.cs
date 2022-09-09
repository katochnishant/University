namespace University.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        //Navigation Property
        public IEnumerable<Student> Students { get; set; }
      
    }
}
