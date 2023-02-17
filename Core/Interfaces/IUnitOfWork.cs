using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
    IMovieRepository MovieRepository { get; }
    IMovieRatingRepository MovieRatingRepository { get; }
    ICommentRepository CommentRepository { get; }
    UserManager<AppUser> UserManager { get; }
    SignInManager<AppUser> SignInManager { get; }
    RoleManager<IdentityRole> RoleManager { get; }
    Task<int> SaveAsync();
}