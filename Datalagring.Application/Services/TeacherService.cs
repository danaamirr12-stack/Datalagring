using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Services
{
    public class TeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _teacherRepository.GetAll();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _teacherRepository.GetById(id);
        }

        public async Task Add(Teacher teacher)
        {
            await _teacherRepository.Add(teacher);
        }

        public async Task Update(Teacher teacher)
        {
            await _teacherRepository.Update(teacher);
        }

        public async Task Remove(int id)
        {
            await _teacherRepository.Remove(id);
        }
    }
}