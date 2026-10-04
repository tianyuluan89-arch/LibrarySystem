namespace LibrarySystem.Models;

public class BorrowRecord
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int ReaderId { get; set; }
    public string BorrowDate { get; set; }
    public string? ReturnDate { get; set; }
}
