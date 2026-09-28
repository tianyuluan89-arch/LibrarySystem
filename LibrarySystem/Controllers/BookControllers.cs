using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private static readonly List<Book> Books = new();

    // GET: api/Book
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAllBooks()
    {
        return Ok(Books);
    }

    // GET: api/Book/{id}
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    // POST: api/Book
    [HttpPost]
    public ActionResult<Book> CreateBook(Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        book.Id = Books.Max(b => b.Id) + 1;
        Books.Add(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    // PUT: api/Book/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (id != book.Id)
        {
            return BadRequest();
        }
        var existingBook = Books.FirstOrDefault(b => b.Id == id);
        if (existingBook == null)
        {
            return NotFound();
        }
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.ISBN = book.ISBN;
        existingBook.AvailableQuantity = book.AvailableQuantity;
        return NoContent();
    }

    // DELETE: api/Book/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        Books.Remove(book);
        return NoContent();
    }
}
