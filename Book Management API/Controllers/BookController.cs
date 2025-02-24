using Book_Management_API.DTOs;
using Book_Management_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management_API.Controllers
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
        public IActionResult AddBook([FromForm]BookAddRequest request)
        {
            BookResponse response = _bookService.AddBook(request);
            
            return Ok(response);
        }

        [HttpGet("")]
        public IActionResult GetAllBooks()
        {
            List<BookResponse> responses = _bookService.GetAllBooks();

            return Ok(responses);
        }

        [HttpGet("id/{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            BookResponse response = _bookService.GetBookById(id);

            return Ok(response);
        }

        [HttpGet("title/{title}")]
        public IActionResult GetBooksByTitle(string title)
        {
            List<BookResponse> responses = _bookService.GetBooksByTitle(title);

            return Ok(responses);
        }

        [HttpGet("author/{author:alpha}")]
        public IActionResult GetBooksByAuthor(string author)
        {
            List<BookResponse> responses = _bookService.GetBooksByAuthor(author);

            return Ok(responses);
        }

        [HttpGet("year/{year:int}")]
        public IActionResult GetBooksByYear(int year)
        {
            List<BookResponse> responses = _bookService.GetBooksByYear(year);

            return Ok(responses);
        }
    }
}
