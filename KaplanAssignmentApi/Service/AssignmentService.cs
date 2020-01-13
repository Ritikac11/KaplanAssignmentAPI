using KaplanAssignmentApi.Data;
using KaplanAssignmentApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaplanAssignmentApi.Service
{
    public class AssignmentService : IAssignmentService
    {

        private readonly AssignmentContext _context;

        public AssignmentService(AssignmentContext context)
        {
            _context = context;
        }
                
        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<Assignment> AddAssignmentAsync(Assignment newAssignment)
        {
            _context.Assignments.Add(newAssignment);
            await _context.SaveChangesAsync();
            return newAssignment;
        }

        public IEnumerable<Assignment> GetByTags(string[] tags)
        {
            var assignment = _context.Assignments.ToList().
                            Where(i => i.Tags.Any(j => tags.Contains(j))).
                            Select(o => o);
            return assignment.ToList();
        }
    }
}
