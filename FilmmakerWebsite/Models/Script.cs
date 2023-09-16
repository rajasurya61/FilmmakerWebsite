namespace FilmmakerWebsite.Models
{
    public class Script
    {
        public int ScriptID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        public string? Author { get; set; }
    }
}
