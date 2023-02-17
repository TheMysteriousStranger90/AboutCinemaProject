namespace Core.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public double RuntimeHours { get; set; }
    public string PictureUrl { get; set; }
    public MovieGenre MovieGenre { get; set; }
    public int MovieGenreId { get; set; }
    public MovieCountry MovieCountry { get; set; }
    public int MovieCountryId { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}