using System.ComponentModel.DataAnnotations;

namespace AuthorBookAPI.Model
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }
        public Author Author { get; set; }
    }
}
