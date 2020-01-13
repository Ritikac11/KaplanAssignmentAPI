using KaplanAssignmentApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaplanAssignmentApi.Service
{
    public interface IAssignmentService
    {
        Task<Assignment> AddAssignmentAsync(Assignment newAssignment);
        Task<Assignment> GetByIdAsync(int id);
        IEnumerable<Assignment> GetByTags(string[] tags);
    }
}
