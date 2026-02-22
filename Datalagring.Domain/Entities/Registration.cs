namespace Datalagring.Domain.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int SessionId { get; set; }
        public Session? Session { get; set; }
        public int ParticipantId { get; set; }
        public Participant? Participant { get; set; }
    }
}