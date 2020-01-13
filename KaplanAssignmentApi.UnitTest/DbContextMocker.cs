using KaplanAssignmentApi.Data;
using Microsoft.EntityFrameworkCore;

namespace KaplanAssignmentApi.UnitTest
{
    public static class DbContextMocker
    {
        public static AssignmentContext GetAssignmentDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<AssignmentContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new AssignmentContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
