namespace Core.Entities;

public class FavouriteFilm : BaseEntity
{
    public string MovieTitle { get; set; }
    public string PictureUrl { get; set; }
    public string MovieCountry { get; set; }
    public string MovieGenre { get; set; }
}