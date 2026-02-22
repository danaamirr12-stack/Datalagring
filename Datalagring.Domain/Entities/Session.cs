namespace Datalagring.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Registration>? Registrations { get; set; }
    }
}