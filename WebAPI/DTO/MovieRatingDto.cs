using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO;

public class MovieRatingDto
{
    [Range(1,5)]
    public int Rate { get; set; }
    public int MovieId { get; set; }
}