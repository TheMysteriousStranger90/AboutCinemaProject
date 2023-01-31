using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AboutCinemaProjectContext _context;

    public CommentRepository(AboutCinemaProjectContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Comment>> GetByMovieIdAsync(int id)
    {
        return await _context.Comments.Where(c => c.MovieId == id).AsNoTracking().ToListAsync();
    }
}