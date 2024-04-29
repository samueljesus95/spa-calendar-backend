using Microsoft.AspNetCore.Mvc;
using spa_calendar_backend.Models;
using spa_calendar_backend.Repositories.Interfaces;

namespace spa_calendar_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController(ITagsRepository tagsRepository) : ControllerBase
    {
        private readonly ITagsRepository _tagsRepository = tagsRepository;

        [HttpGet]
        public ActionResult GetAllTags()
        {
            var tags = _tagsRepository.GetAllTags();

            return Ok(tags);
        }

        [HttpGet("{title}")]
        public IActionResult GetTagsByTitle(string title)
        {
            var tags = _tagsRepository.GetTagsByTitle(title);
            if (tags == null)
                return NotFound();

            return Ok(tags);
        }

        [HttpPost]
        public IActionResult AddTags([FromBody] Tag tags)
        {
            if (tags == null)
                return BadRequest();

            var existingTags = _tagsRepository.GetTagsByTitle(tags.Title);
            if (existingTags != null)
                return BadRequest();

            _tagsRepository.AddTags(tags);
            return CreatedAtAction(nameof(GetTagsByTitle), new { title = tags.Title }, tags);
        }

        [HttpPut("{title}")]
        public IActionResult UpdateTags(string title, [FromBody] Tag tags)
        {
            if (tags == null || !title.Equals(tags.Title))
                return BadRequest();

            var existingTags = _tagsRepository.GetTagsByTitle(title);
            if (existingTags == null)
                return NotFound();

            _tagsRepository.UpdateTags(existingTags);
            return NoContent();
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteTags(string title)
        {
            var existingTags = _tagsRepository.GetTagsByTitle(title);
            if (existingTags == null)
                return NotFound();

            _tagsRepository.DeleteTags(title);
            return NoContent();
        }
    }
}
