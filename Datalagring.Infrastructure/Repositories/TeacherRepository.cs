using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;
using Datalagring.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Datalagring.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task Add(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var teacher = await GetById(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}