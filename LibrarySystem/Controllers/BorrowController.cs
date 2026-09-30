using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        [HttpPost("borrow")]
        public IActionResult Borrow(int bookId, int readerId)
        {
            // 暂时注释所有 DataStore 代码
            /*
            var book = DataStore.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                return NotFound("Book not found");
            }
            if (book.AvailableQuantity <= 0)
            {
                return BadRequest("No available copies");
            }
            book.AvailableQuantity--;
            */

            var result = new
            {
                id = 1,
                bookId = bookId,
                readerId = readerId,
                borrowDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                returnDate = (string?)null
            };
            return Ok(result);
        }
    }
}
