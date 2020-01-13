using System;
using Xunit;
using KaplanAssignmentApi.Data;
using KaplanAssignmentApi.Model;

namespace KaplanAssignmentApi.UnitTest
{
    public static class DbContextExtensions
    {
        public static void Seed(this AssignmentContext dbContext)
        {
            dbContext.Assignments.AddRange(
                new Assignment { Id = 1, Name = "Set A", Title = "A", Description = "", Type = "Easy", Duration = 30, Tags = new[] { "c#", ".Net" } },
                new Assignment { Id = 2, Name = "Set B", Title = "B", Description = "", Type = "Difficult", Duration = 30, Tags = new[] { "C#" } },
                new Assignment { Id = 3, Name = "Set C", Title = "C", Description = "", Type = "Intermediary", Duration = 60, Tags = new[] { "Java", "C#" } },
                new Assignment { Id = 4, Name = "Set D", Title = "D", Description = "", Type = "Easy", Duration = 60, Tags = new[] { "Python", "Java" } }
            );
            dbContext.SaveChanges();
        }
    }
}
