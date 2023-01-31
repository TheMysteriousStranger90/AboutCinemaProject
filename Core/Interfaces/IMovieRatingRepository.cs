using Core.Entities;

namespace Core.Interfaces;

public interface IMovieRatingRepository
{
    Task Vote(MovieRating movieRating);
}