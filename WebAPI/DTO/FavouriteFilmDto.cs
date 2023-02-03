using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class FavouriteFilmDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string MovieTitle { get; set; }
    [Required]
    public string PictureUrl { get; set; }
    [Required]
    public string MovieCountry { get; set; }
    [Required]
    public string MovieGenre { get; set; }
}