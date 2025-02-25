namespace Book_Management_API.DTOs
{
    public class BookUpdateRequest
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
    }
}
