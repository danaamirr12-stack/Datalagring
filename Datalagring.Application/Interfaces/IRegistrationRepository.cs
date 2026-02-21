using Datalagring.Domain.Entities;


namespace Datalagring.Application.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Registration> GetById(int id);
        Task<List<Registration>> GetAll();
        Task<List<Registration>> GetByParticipantId(int participantId);
        Task<List<Registration>> GetBySessionId(int sessionId);
        Task Add(Registration registration);
        Task Remove(int id);
    }
}