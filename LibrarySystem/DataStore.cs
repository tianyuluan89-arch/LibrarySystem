using LibrarySystem.Models;

namespace LibrarySystem
{
    public static class DataStore
    {
        // 初始化集合，防止 null
        public static List<Book> Books { get; set; } = new List<Book>();
        public static int NextBookId = 1;
    }
}
