using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaplanAssignmentApi.Model;
using KaplanAssignmentApi.Service;

namespace KaplanAssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _service;

        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        // GET: api/Assignment/5
        [HttpGet("{id}"), ActionName(nameof(GetByIdAsync))]
        public async Task<ActionResult<Assignment>> GetByIdAsync(int id)
        {
            if(id <= 0)
                return BadRequest("Student id must be higher than zero");

            var assignment = await _service.GetByIdAsync(id);
            
            return assignment == null ? NotFound() : (ActionResult<Assignment>)Ok(assignment);
        }

        // POST: api/Assignment/search
        [HttpPost("search")]
        public ActionResult<IEnumerable<Assignment>> SearchByTag([FromBody]string[] tags)
        {
            var assignment = _service.GetByTags(tags);

            if (assignment == null & assignment.Count() > 0)
            {
                return NotFound("No assignment found");
            }
            return assignment.ToList();
        }

        // POST: api/Assignment
        [HttpPost]
        public async Task<ActionResult<Assignment>> AddAsync([FromBody]Assignment assignment)
        {
            if(assignment == null)
            {
                return BadRequest();
            }
            var newAssignment = await _service.AddAssignmentAsync(assignment);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newAssignment.Id }, newAssignment);
        }
    }
}
