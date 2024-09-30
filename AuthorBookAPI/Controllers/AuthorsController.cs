using AuthorBookAPI.Model.DTO;
using AuthorBookAPI.Model;
using AuthorBookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Email = dto.Email
            };

            var createdAuthor = await _authorRepository.CreateAuthorAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = createdAuthor.Id }, createdAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAuthorDto dto)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
                return NotFound();

            existingAuthor.Name = dto.Name;
            existingAuthor.Email = dto.Email;

            await _authorRepository.UpdateAuthorAsync(existingAuthor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorRepository.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
