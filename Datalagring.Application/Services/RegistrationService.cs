using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Services
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<List<Registration>> GetAll()
        {
            return await _registrationRepository.GetAll();
        }

        public async Task<Registration> GetById(int id)
        {
            return await _registrationRepository.GetById(id);
        }

        public async Task<List<Registration>> GetByParticipantId(int participantId)
        {
            return await _registrationRepository.GetByParticipantId(participantId);
        }

        public async Task<List<Registration>> GetBySessionId(int sessionId)
        {
            return await _registrationRepository.GetBySessionId(sessionId);
        }

        public async Task Add(Registration registration)
        {
            await _registrationRepository.Add(registration);
        }

        public async Task Remove(int id)
        {
            await _registrationRepository.Remove(id);
        }
    }
}