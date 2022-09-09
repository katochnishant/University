namespace University.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public string TeacherId { get; set; }
    
        //Navigaton Properties
        public Course Course { get; set; }

        public Teacher Teacher { get; set; }
    
    
    }
}
