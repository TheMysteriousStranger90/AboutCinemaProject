namespace Core.Entities;

public class Comment : BaseEntity
{
    public AppUser AppUser { get; set; }
    public string AppUserId { get; set; }
    public Movie Movie { get; set; }
    public int MovieId { get; set; }
    public string Text { get; set; }
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
}