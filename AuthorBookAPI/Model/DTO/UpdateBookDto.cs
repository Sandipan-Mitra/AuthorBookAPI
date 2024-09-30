namespace AuthorBookAPI.Model.DTO
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int UpdatedBy { get; set; }
    }
}
