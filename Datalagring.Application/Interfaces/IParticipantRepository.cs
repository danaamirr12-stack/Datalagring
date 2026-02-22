using Datalagring.Domain.Entities;

namespace Datalagring.Application.Interfaces
{
    public interface IParticipantRepository
    {
        Task<Participant> GetById(int id);
        Task<List<Participant>> GetAll();
        Task Add(Participant participant);
        Task Update(Participant participant);
        Task Remove(int id);
    }
}