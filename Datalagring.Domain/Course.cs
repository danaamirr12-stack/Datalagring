namespace Datalagring.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int WeeksDuration { get; set; }
        public string? CourseDescription { get; set; }
        public List<Session>? Sessions { get; set; }
    }
}