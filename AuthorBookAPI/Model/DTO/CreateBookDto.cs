namespace AuthorBookAPI.Model.DTO
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int CreatedBy { get; set; }
    }
}
