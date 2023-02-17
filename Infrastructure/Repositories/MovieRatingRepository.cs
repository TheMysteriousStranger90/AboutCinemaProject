using System.Security.Claims;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRatingRepository : IMovieRatingRepository
{
    private readonly AboutCinemaProjectContext _context;

    public MovieRatingRepository(
        AboutCinemaProjectContext context)
    {
        _context = context;
    }

    public async Task Vote(MovieRating movieRating, string appUserID)
    {
        if (appUserID == null) { return; }

        var currentRating = await _context.MovieRating
            .FirstOrDefaultAsync(x => x.MovieId == movieRating.MovieId &&
                                      x.AppUserId == appUserID);

        if (currentRating == null)
        {
            movieRating.AppUserId = appUserID;
            movieRating.RatingDate = DateTime.Today;
            _context.Add(movieRating);
            await _context.SaveChangesAsync();
        }
        else
        {
            currentRating.Rate = movieRating.Rate;
            await _context.SaveChangesAsync();
        }
    }
}