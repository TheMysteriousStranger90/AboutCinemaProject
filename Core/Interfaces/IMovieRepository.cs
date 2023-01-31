using Core.Entities;

namespace Core.Interfaces;

public interface IMovieRepository
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<IReadOnlyList<Movie>> GetMoviesAsync();
    Task<IReadOnlyList<MovieCountry>> GetMovieCountriesAsync();
    Task<IReadOnlyList<MovieGenre>> GetMovieGenresAsync();
}