using Datalagring.Application.Interfaces;
using Datalagring.Domain.Entities;

namespace Datalagring.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAll()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetById(int id)
        {
            return await _courseRepository.GetById(id);
        }

        public async Task Add(Course course)
        {
            await _courseRepository.Add(course);
        }

        public async Task Update(Course course)
        {
            await _courseRepository.Update(course);
        }

        public async Task Remove(int id)
        {
            await _courseRepository.Remove(id);
        }
    }
}