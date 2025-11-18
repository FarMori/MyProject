using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Service;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(string Name)
        {
            var author = await _service.CreateAuthorAsync(Name);
            return Ok(author);

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _service.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpGet("by-name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var author = await _service.GetByNameAsync(name);
            if (author == null)
                return NotFound();

            return Ok(author);
        }
    }
}
