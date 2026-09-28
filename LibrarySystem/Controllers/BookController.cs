using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        // 内存模拟数据库
        private static readonly List<Book> books = new();
        private static int nextId = 1;

        // GET: api/Book 获取全部书籍
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(books);
        }

        // GET: api/Book/{id} 根据id获取单本书
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Book 新增书籍
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT: api/Book/{id} 修改书籍
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Isbn = book.Isbn;
            existingBook.AvailableQuantity = book.AvailableQuantity;

            return NoContent();
        }

        // DELETE: api/Book/{id} 删除书籍
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);
            return NoContent();
        }
    }
}
