using System;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Interfaces
{
    public interface ISessionRepository
    {
        Task<Session> GetById(int id);
        Task<List<Session>> GetAll();
        Task<List<Session>> GetByCourseId(int courseId);
        Task<List<Session>> GetByTeacherId(int teacherId);
        Task Add(Session session);
        Task Update(Session session);
        Task Remove(int id);
    }
}