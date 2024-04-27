using Microsoft.AspNetCore.Mvc;
using spa_calendar_backend.Models;
using spa_calendar_backend.Models.DTOs;
using spa_calendar_backend.Repositories;

namespace spa_calendar_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssignmentRepository assignmentRepository) : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;

        [HttpGet]
        public ActionResult GetAllAssignments()
        {
            var assignments = _assignmentRepository.GetAllAssignments();
            
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _assignmentRepository.GetAssignmentById(id);
            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult AddAssignment([FromBody] AssignmentDTO assignmentDTO)
        {
            if(assignmentDTO == null)
                return BadRequest();

            var assignmentTag = new List<Tag>();
            if (assignmentDTO.Tags != null)
            {
                foreach (var tags in assignmentDTO.Tags)
                {
                    foreach (var assignmentTags in assignmentTag)
                    {
                        assignmentTags.Title = tags;
                    }
                }
            }

            var assignment = new Assignment
            {
                Title = assignmentDTO.Title,
                Description = assignmentDTO.Description,
                StartDate = assignmentDTO.Start,
                EndDate = assignmentDTO.End,
                Tags = assignmentTag
            };

            _assignmentRepository.AddAssignment(assignment);
            return CreatedAtAction(nameof(GetAssignmentById), new { id = assignment.Id }, assignment);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateAssignment(int id, [FromBody] AssignmentDTO assignmentDTO)
        //{
        //    if (assignmentDTO == null || id != assignmentDTO.Id)
        //        return BadRequest();

        //    var existingAssignment = _assignmentRepository.GetAssignmentById(id);
        //    if (existingAssignment == null)
        //        return NotFound();

        //    _assignmentRepository.UpdateAssignment(assignment);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteAssignment(int id)
        //{
        //    var existingAssignment = _assignmentRepository.GetAssignmentById(id);
        //    if(existingAssignment == null)
        //        return NotFound();

        //    _assignmentRepository.DeleteAssignment(id);
        //    return NoContent();
        //}
    }
}
