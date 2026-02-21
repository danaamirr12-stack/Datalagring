using Datalagring.Domain.Entities;

namespace Datalagring.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetById(int id);
        Task<List<Course>> GetAll();
        Task Add(Course course);
        Task Update(Course course);
        Task Remove(int id);
    }
}