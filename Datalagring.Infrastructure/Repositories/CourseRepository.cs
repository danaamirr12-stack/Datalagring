using Microsoft.EntityFrameworkCore;
using Datalagring.Domain.Entities;
using Datalagring.Application.Interfaces;
using Datalagring.Infrastructure.Database;

namespace Datalagring.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _db;

        public CourseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await _db.Courses.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
        }
    }
}