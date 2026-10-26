using LibrarySystem.Models;
using System.Collections.Generic;

namespace LibrarySystem.Data
{
    public class DataStore
    {
        // 静态单例 Instance，解决红色波浪
        public static DataStore Instance { get; } = new DataStore();

        public List<Book> Books { get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; }
        public List<Reader> Readers { get; set; }

        private DataStore()
        {
            Books = new List<Book>();
            BorrowRecords = new List<BorrowRecord>();
            Readers = new List<Reader>();
        }
    }
}
