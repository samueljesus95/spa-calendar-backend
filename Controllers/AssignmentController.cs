﻿using Microsoft.AspNetCore.Mvc;
using spa_calendar_backend.Models;
using spa_calendar_backend.Repositories;

namespace spa_calendar_backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentController(IAssignmentRepository assignmentRepository) { _assignmentRepository = assignmentRepository; }
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
        public IActionResult AddAssignment([FromBody] Assignment assignment)
        {
            if(assignment == null)
                return BadRequest();

            _assignmentRepository.AddAssignment(assignment);
            return CreatedAtAction(nameof(GetAssignmentById), new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, [FromBody] Assignment assignment)
        {
            if (assignment == null || id != assignment.Id)
                return BadRequest();

            var existingAssignment = _assignmentRepository.GetAssignmentById(id);
            if (existingAssignment == null)
                return NotFound();

            _assignmentRepository.UpdateAssignment(assignment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var existingAssignment = _assignmentRepository.GetAssignmentById(id);
            if(existingAssignment == null)
                return NotFound();

            _assignmentRepository.DeleteAssignment(id);
            return NoContent();
        }
    }
}