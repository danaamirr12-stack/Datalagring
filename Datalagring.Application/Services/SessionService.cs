using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Services
{
    public class SessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetAll()
        {
            return await _sessionRepository.GetAll();
        }

        public async Task<Session> GetById(int id)
        {
            return await _sessionRepository.GetById(id);
        }

        public async Task<List<Session>> GetByCourseId(int courseId)
        {
            return await _sessionRepository.GetByCourseId(courseId);
        }

        public async Task<List<Session>> GetByTeacherId(int teacherId)
        {
            return await _sessionRepository.GetByTeacherId(teacherId);
        }

        public async Task Add(Session session)
        {
            await _sessionRepository.Add(session);
        }

        public async Task Update(Session session)
        {
            await _sessionRepository.Update(session);
        }

        public async Task Remove(int id)
        {
            await _sessionRepository.Remove(id);
        }
    }
}