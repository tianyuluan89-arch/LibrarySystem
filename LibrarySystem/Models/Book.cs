using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Isbn is required")]
        public string Isbn { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int AvailableQuantity { get; set; }
    }
}
