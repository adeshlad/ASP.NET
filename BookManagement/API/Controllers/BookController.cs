using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromForm] BookAddRequest request)
        {
            BookResponse response = await _bookService.AddBook(request);

            return CreatedAtAction(nameof(GetBookById), new { id = response.Id }, response);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            IEnumerable<BookResponse> responses = await _bookService.GetAllBooks();

            return Ok(new { books = responses });
        }

        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            BookResponse? response = await _bookService.GetBookById(id);

            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBooksByParams([FromQuery] string? title, [FromQuery] string? author, [FromQuery] int? year)
        {
            IEnumerable<BookResponse> responses = await _bookService.GetBooksByParams(title, author, year);

            return Ok(new { books = responses });
        }

        [HttpPut("id/{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromForm] BookUpdateRequest request)
        {
            BookResponse? response = await _bookService.UpdateBook(id, request);

            return Ok(response);
        }

        [HttpDelete("id/{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            bool response = await _bookService.DeleteBook(id);

            return response ? NoContent() : NotFound();
        }
    }
}
