using KaplanAssignmentApi.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace KaplanAssignmentApi.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AssignmentContext>();
                context.Database.EnsureCreated();

                if(context.Assignments != null && context.Assignments.Any())
                {
                    return;
                }

                var assignments = GetAssignments().ToArray();
                context.Assignments.AddRange(assignments);
                context.SaveChanges();
            }
        }

        public static List<Assignment> GetAssignments()
        {
            List<Assignment> assignments = new List<Assignment>()
            {
                new Assignment {Name = "Set A" , Title = "A", Description = "", Type = "Easy", Duration = 30, Tags = new [] {"c#", ".Net"} },
                new Assignment {Name = "Set B" , Title = "B", Description = "", Type = "Difficult", Duration = 30, Tags = new [] {"C#"} },
                new Assignment {Name = "Set C" , Title = "C", Description = "", Type = "Intermediary", Duration = 60, Tags = new [] {"Java", "C#"} },
                new Assignment {Name = "Set D" , Title = "D", Description = "", Type = "Easy", Duration = 60, Tags = new [] {"Python", "Java"} }
            };
            return assignments;
        }
    }
}
