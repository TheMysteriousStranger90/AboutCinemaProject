using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AboutCinemaProjectContext _context;
    public MovieRepository(AboutCinemaProjectContext context)
    {
        _context = context;
    }
    
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.MovieGenre)
            .Include(m => m.MovieCountry)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IReadOnlyList<Movie>> GetMoviesAsync()
    {
        return await _context.Movies
            .Include(m => m.MovieGenre)
            .Include(m => m.MovieCountry)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<MovieCountry>> GetMovieCountriesAsync()
    {
        return await _context.MovieCountry.ToListAsync();
    }

    public async Task<IReadOnlyList<MovieGenre>> GetMovieGenresAsync()
    {
        return await _context.MovieGenre.ToListAsync();
    }
}