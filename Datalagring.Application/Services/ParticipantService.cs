using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Services
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<List<Participant>> GetAll()
        {
            return await _participantRepository.GetAll();
        }

        public async Task<Participant> GetById(int id)
        {
            return await _participantRepository.GetById(id);
        }

        public async Task Add(Participant participant)
        {
            await _participantRepository.Add(participant);
        }

        public async Task Update(Participant participant)
        {
            await _participantRepository.Update(participant);
        }

        public async Task Remove(int id)
        {
            await _participantRepository.Remove(id);
        }
    }
}