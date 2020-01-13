using Xunit;
using System.Linq;
using System.Threading.Tasks;
using KaplanAssignmentApi.Model;
using KaplanAssignmentApi.Data;
using KaplanAssignmentApi.Service;

namespace KaplanAssignmentApi.UnitTest
{
    public class AssignmentServiceTest
    {
        private readonly AssignmentContext dbContext;
        public AssignmentServiceTest()
        {
            dbContext = DbContextMocker.GetAssignmentDbContext("MockData");
        }

        [Fact]
        public async Task GetAssignmentByIdAsync_ValidId_ReturnsAssignmentData()
        {
            // Arrange
            var service = new AssignmentService(dbContext);
            int id = 1;

            // Act
            var response = await service.GetByIdAsync(id);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Name.Equals("Set A"));
            Assert.True(response.Title.Equals("A"));
        }

        [Fact]
        public async Task GetAssignmentByIdAsync_InvalidId_ReturnsValidation()
        {
            // Arrange
            var service = new AssignmentService(dbContext);
            int id = -1;

            // Act
            var response = await service.GetByIdAsync(id);
            dbContext.Dispose();

            // Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetAssignmentByIdTagsAsync_ValidTags_ReturnsAssignment()
        {
            // Arrange
            var service = new AssignmentService(dbContext);
            string[] tags = new[] { "c#", ".Net" };

            // Act
            var response = service.GetByTags(tags);
            dbContext.Dispose();

            // Assert
            Assert.True(response.Count() > 0);
        }

        [Fact]
        public void GetAssignmentByIdTagsAsync_InvalidTags_ReturnsNull()
        {
            // Arrange
            var service = new AssignmentService(dbContext);
            string[] tags = new[] { "qwer", "asdf" };

            // Act
            var response = service.GetByTags(tags);
            dbContext.Dispose();

            // Assert
            Assert.True(response.Count() == 0);
        }

        [Fact]
        public async Task AddAssignmentAsync_ValidData_ReturnsAssignment()
        {
            // Arrange
            var service = new AssignmentService(dbContext);
            Assignment assignment = new Assignment { Id= 5, Name = "Set A", Title = "A", Description = "", Type = "Easy", Duration = 30, Tags = new[] { "c#", ".Net" } },

            // Act
            response = await service.AddAssignmentAsync(assignment);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
        }        
    }
}
