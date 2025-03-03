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
        public async Task<IActionResult> AddBook(BookAddRequest request)
        {
            BookResponse response = await _bookService.AddBook(request);

            return CreatedAtAction(nameof(GetBookById), new { id = response.Id }, response);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] int? year)
        {
            IEnumerable<BookResponse> responses = null;

			if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author) && !year.HasValue)
            {
				responses = await _bookService.GetAllBooks();
            }
            else
            {
				responses = await _bookService.GetBooksByAttributes(title, author, year);
			}

			return Ok(new { books = responses });
        }

        [HttpGet("id/{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            BookResponse? response = await _bookService.GetBookById(id);

            return Ok(response);
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
