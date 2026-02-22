using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;
using Datalagring.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Datalagring.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Session> GetById(int id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task<List<Session>> GetAll()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<List<Session>> GetByCourseId(int courseId)
        {
            return await _context.Sessions.Where(s => s.CourseId == courseId).ToListAsync();
        }

        public async Task<List<Session>> GetByTeacherId(int teacherId)
        {
            return await _context.Sessions.Where(s => s.TeacherId == teacherId).ToListAsync();
        }

        public async Task Add(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Session session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var session = await GetById(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }
    }
}