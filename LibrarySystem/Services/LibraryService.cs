using LibrarySystem.Data;
using LibrarySystem.Models;
using System.Linq;

namespace LibrarySystem.Services
{
    public class LibraryService
    {
        private readonly DataStore _store = DataStore.Instance;

        public BorrowRecord BorrowBook(int bookId, int readerId)
        {
            var book = _store.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null) throw new KeyNotFoundException("Book not found");
            if (book.AvailableQuantity <= 0) throw new InvalidOperationException("No available copies");

            book.AvailableQuantity--;
            var record = new BorrowRecord
            {
                Id = _store.BorrowRecords.Any()?
                _store.BorrowRecords.Max(r=>r.Id)+1:1,
                BookId = bookId,
                ReaderId = readerId,
                BorrowDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                ReturnDate = null
            };
            _store.BorrowRecords.Add(record);
            return record;
        }

        public void ReturnBook(int recordId)
        {
            var record = _store.BorrowRecords.FirstOrDefault(r => r.Id == recordId);
            if (record == null) throw new KeyNotFoundException("Record not found");
            if (record.ReturnDate != null) throw new InvalidOperationException("Already returned");

            var book = _store.Books.First(b => b.Id == record.BookId);
            book.AvailableQuantity++;
            record.ReturnDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public void AddBook(Book book)
        {
            _store.Books.Add(book);
        }

        public Book? GetBookById(int id)
        {
            return _store.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
