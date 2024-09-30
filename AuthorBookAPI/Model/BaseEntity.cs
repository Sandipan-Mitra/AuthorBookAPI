namespace AuthorBookAPI.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
