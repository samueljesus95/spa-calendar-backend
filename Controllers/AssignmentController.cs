using Microsoft.AspNetCore.Mvc;
using spa_calendar_backend.Models.DTOs;
using spa_calendar_backend.Services.Interfaces;

namespace spa_calendar_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
    {
        private readonly IAssignmentService _assignmentService = assignmentService;

        [HttpGet]
        public ActionResult GetAllAssignments()
        {
            var assignments = _assignmentService.GetAllAssignments();
            
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _assignmentService.GetAssignmentById(id);
            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult AddAssignment([FromBody] AssignmentDTO assignmentDTO)
        {
            if(assignmentDTO == null)
                return BadRequest();

            _assignmentService.AddAssignment(assignmentDTO);
            return CreatedAtAction(nameof(GetAssignmentById), new { id = assignmentDTO.Id }, assignmentDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, [FromBody] AssignmentDTO assignmentDTO)
        {
            if (assignmentDTO == null || id != assignmentDTO.Id)
                return BadRequest();

            var existingAssignment = _assignmentService.GetAssignmentById(id);
            if (existingAssignment == null)
                return NotFound();

            _assignmentService.UpdateAssignment(existingAssignment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var existingAssignment = _assignmentService.GetAssignmentById(id);
            if (existingAssignment == null)
                return NotFound();

            _assignmentService.DeleteAssignment(id);
            return NoContent();
        }
    }
}
