using System.Security.Claims;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRatingRepository : IMovieRatingRepository
{
    private readonly AboutCinemaProjectContext context;

    public MovieRatingRepository(
        AboutCinemaProjectContext context)
    {
        this.context = context;
    }

    public async Task Vote(MovieRating movieRating)
    {


        var currentRating = await context.MovieRating
            .FirstOrDefaultAsync(x => x.MovieId == movieRating.MovieId);

        if (currentRating == null)
        {
            movieRating.RatingDate = DateTime.Today;
            context.Add(movieRating);
            await context.SaveChangesAsync();
        }
        else
        {
            currentRating.Rate = movieRating.Rate;
            await context.SaveChangesAsync();
        }
    }
}