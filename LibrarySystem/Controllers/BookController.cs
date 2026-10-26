using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Services;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly LibraryService _service = new LibraryService();

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            _service.AddBook(book);
            return Ok(book);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            if (book == null) return NotFound();
            return book;
        }
    }
}
