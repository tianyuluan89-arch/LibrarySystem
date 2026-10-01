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
