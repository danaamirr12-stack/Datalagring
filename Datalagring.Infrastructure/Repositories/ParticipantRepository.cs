using System;
using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;
using Datalagring.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Datalagring.Infrastructure.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Participant> GetById(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task<List<Participant>> GetAll()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task Add(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Participant participant)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var participant = await GetById(id);
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
        }
    }
}