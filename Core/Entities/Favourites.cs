namespace Core.Entities;

public class Favourites
{
    public Favourites()
    {
    }

    public Favourites(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public List<FavouriteFilm> FavouriteFilms { get; set; } = new List<FavouriteFilm>();
    public string ClientSecret { get; set; }
}