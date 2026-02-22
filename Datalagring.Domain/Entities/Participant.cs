namespace Datalagring.Domain.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Registration>? Registrations { get; set; }
    }
}