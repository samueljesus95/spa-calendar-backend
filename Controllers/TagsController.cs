using Microsoft.AspNetCore.Mvc;
using spa_calendar_backend.Models;
using spa_calendar_backend.Repositories;

namespace spa_calendar_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsRepository _tagsRepository;
        public TagsController(ITagsRepository tagsRepository) { _tagsRepository = tagsRepository; }
        [HttpGet]
        public ActionResult GetAllTags()
        {
            var tags = _tagsRepository.GetAllTags();

            return Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult GetTagsById(int id)
        {
            var tags = _tagsRepository.GetTagsById(id);
            if (tags == null)
                return NotFound();

            return Ok(tags);
        }

        [HttpPost]
        public IActionResult AddTags([FromBody] Tags tags)
        {
            if (tags == null)
                return BadRequest();

            _tagsRepository.AddTags(tags);
            return CreatedAtAction(nameof(GetTagsById), new { id = tags.Id }, tags);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTags(int id, [FromBody] Tags tags)
        {
            if (tags == null || id != tags.Id)
                return BadRequest();

            var existingTags = _tagsRepository.GetTagsById(id);
            if (existingTags == null)
                return NotFound();

            _tagsRepository.UpdateTags(existingTags);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTags(int id)
        {
            var existingTags = _tagsRepository.GetTagsById(id);
            if (existingTags == null)
                return NotFound();

            _tagsRepository.DeleteTags(id);
            return NoContent();
        }
    }
}
