using KaplanAssignmentApi.Model;
using Microsoft.EntityFrameworkCore;

namespace KaplanAssignmentApi.Data
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Assignment>()
            .Property(b => b._Tags).HasColumnName("Tags");

            builder.Entity<Assignment>().ToTable("Assignment");
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
