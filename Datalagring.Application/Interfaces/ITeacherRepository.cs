using Datalagring.Domain.Entities;

namespace Datalagring.Application.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetById(int id);
        Task<List<Teacher>> GetAll();
        Task Add(Teacher teacher);
        Task Update(Teacher teacher);
        Task Remove(int id);
    }
}