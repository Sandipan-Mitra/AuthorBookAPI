using System.ComponentModel.DataAnnotations;

namespace AuthorBookAPI.Model
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }
}
