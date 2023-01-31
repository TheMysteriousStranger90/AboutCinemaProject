using Core.Entities;

namespace Core.Interfaces;

public interface ICommentRepository
{
    Task<IReadOnlyList<Comment>> GetByMovieIdAsync(int id);
}