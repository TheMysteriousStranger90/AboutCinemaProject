using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class FavouritesDto
{
    [Required]
    public string Id { get; set; }
    public List<FavouriteFilmDto> FavouriteFilms { get; set; }
    public string ClientSecret { get; set; }
}