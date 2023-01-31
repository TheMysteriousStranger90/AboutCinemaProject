using Core.Entities;

namespace Core.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByMovieIdAsync(int id);
}