namespace Core.Entities;

public class MovieRating : BaseEntity
{
    public int Rate { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
}