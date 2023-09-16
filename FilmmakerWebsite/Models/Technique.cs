namespace FilmmakerWebsite.Models
{
    public class Technique
    {
        public int TechniqueID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Example { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
