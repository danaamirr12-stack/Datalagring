using Datalagring.Application.Interfaces;
using Datalagring.Application.Services;
using Datalagring.Domain.Entities;
using Moq;

namespace Datalagring.Tests
{
    public class CourseServiceTests
    {
        [Fact]
        public async Task GetAll_ShouldReturnAllCourses()
        {
            var fakeCourses = new List<Course>
            {
                new Course { Id = 1, Name = "C# Grundkurs", WeeksDuration = 4, CourseDescription = "Intro till C#" },
                new Course { Id = 2, Name = "Databaser", WeeksDuration = 6, CourseDescription = "SQL och EF Core" }
            };

            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(fakeCourses);

            var service = new CourseService(mockRepo.Object);

            var result = await service.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("C# Grundkurs", result[0].Name);
        }
    }
}