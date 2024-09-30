using AuthorBookAPI.Model.DTO;
using AuthorBookAPI.Model;
using AuthorBookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                Author = new Author
                {
                    Id = dto.AuthorId
                },
                CreatedBy = dto.AuthorId
            };

            var createdBook = await _bookRepository.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto dto)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = dto.Title;
            existingBook.ISBN = dto.ISBN;
            existingBook.Author.Id = dto.AuthorId;
            existingBook.UpdatedOn = DateTime.Now;
            existingBook.UpdatedBy = dto.AuthorId;

            await _bookRepository.UpdateBookAsync(existingBook);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
