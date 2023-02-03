namespace WebAPI.DTO;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public double RuntimeHours { get; set; }
    public string PictureUrl { get; set; }
    public string MovieGenre { get; set; }
    public string MovieCountry { get; set; }
    public int? MovieRating { get; set; }
    public ICollection<CommentDto>? Comments { get; set; } = new List<CommentDto>();
    public ICollection<AppUserDto>? WatchLaterUsers { get; set; } = new List<AppUserDto>();
}