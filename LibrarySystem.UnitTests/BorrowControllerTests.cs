using Xunit;
using LibrarySystem;
using LibrarySystem.Models;
using LibrarySystem.Services;
using LibrarySystem.Data;

namespace LibrarySystem.UnitTests
{
    public class LibraryServiceTests
    {
        [Fact]
        public void Borrow_ValidBookId_ReduceAvailableQuantity()
        {
            DataStore.Instance.Books.Clear();
            DataStore.Instance.BorrowRecords.Clear();

            var service = new LibraryService();
            var book = new Book
            {
                Id = 1,
                Title = "Test Book",
                Author = "Author A",
                AvailableQuantity = 2
            };
            service.AddBook(book);

            // Act
            var result = service.BorrowBook(1, 1);
            var bookAfter = service.GetBookById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, bookAfter.AvailableQuantity);
        }

        [Fact]
        public void Borrow_ZeroStock_ThrowException()
        {
            DataStore.Instance.Books.Clear();
            DataStore.Instance.BorrowRecords.Clear();

            var service = new LibraryService();
            var book = new Book
            {
                Id = 2,
                Title = "Empty Book",
                Author = "Test",
                AvailableQuantity = 0
            };
            service.AddBook(book);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => service.BorrowBook(2, 1));
            Assert.Equal("No available copies", ex.Message);
        }

        [Fact]
        public void ReturnBook_ValidRecord_RestoreQuantity()
        {
            DataStore.Instance.Books.Clear();
            DataStore.Instance.BorrowRecords.Clear();

            var service = new LibraryService();
            var book = new Book
            {
                Id = 3,
                Title = "Return Test Book",
                Author = "Test",
                AvailableQuantity = 1
            };
            service.AddBook(book);

            // Act
            var borrowRecord = service.BorrowBook(3, 1);
            service.ReturnBook(borrowRecord.Id);
            var bookAfterReturn = service.GetBookById(3);

            // Assert
            Assert.Equal(1, bookAfterReturn.AvailableQuantity);
            Assert.NotNull(borrowRecord.ReturnDate);
        }

        [Fact]
        public void Return_AlreadyReturned_ThrowException()
        {
            DataStore.Instance.Books.Clear();
            DataStore.Instance.BorrowRecords.Clear();

            var service = new LibraryService();
            var book = new Book
            {
                Id = 4,
                Title = "Already Returned Book",
                Author = "Test",
                AvailableQuantity = 1
            };
            service.AddBook(book);

            var borrowRecord = service.BorrowBook(4, 1);
            service.ReturnBook(borrowRecord.Id);

            var ex = Assert.Throws<InvalidOperationException>(() => service.ReturnBook(borrowRecord.Id));
            Assert.Equal("Already returned", ex.Message);
        }
    }
}
