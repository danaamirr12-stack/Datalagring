using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;
using Datalagring.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Datalagring.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Registration> GetById(int id)
        {
            return await _context.Registrations.FindAsync(id);
        }

        public async Task<List<Registration>> GetAll()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<List<Registration>> GetByParticipantId(int participantId)
        {
            return await _context.Registrations.Where(r => r.ParticipantId == participantId).ToListAsync();
        }

        public async Task<List<Registration>> GetBySessionId(int sessionId)
        {
            return await _context.Registrations.Where(r => r.SessionId == sessionId).ToListAsync();
        }

        public async Task Add(Registration registration)
        {
            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var registration = await GetById(id);
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
        }
    }
}