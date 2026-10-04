using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Services;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly LibraryService _service = new LibraryService();

        [HttpPost("borrow")]
        public ActionResult<BorrowRecord> Borrow(int bookId, int readerId)
        {
            try
            {
                var res = _service.BorrowBook(bookId, readerId);
                return Ok(res);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Book not found");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("return/{recordId}")]
        public ActionResult Return(int recordId)
        {
            try
            {
                _service.ReturnBook(recordId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Record not found");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
