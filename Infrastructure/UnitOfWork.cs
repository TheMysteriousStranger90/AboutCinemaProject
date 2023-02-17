using System.Collections;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AboutCinemaProjectContext _context;
    private Hashtable _repositories;

    public UnitOfWork(AboutCinemaProjectContext context, RoleManager<IdentityRole> _roleManager,
        UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
    {
        _context = context;
        roleManager = _roleManager;
        userManager = _userManager;
        signInManager = _signInManager;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        if (_repositories == null) _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (GenericRepository<T>)_repositories[type];
    }

    private IMovieRepository _movieRepository;
    public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
    
    private IMovieRatingRepository _movieRatingRepository;
    public IMovieRatingRepository MovieRatingRepository => _movieRatingRepository ??= new MovieRatingRepository(_context);

    private ICommentRepository _commentRepository;
    public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);
    
    private readonly UserManager<AppUser> userManager;

    public UserManager<AppUser> UserManager
    {
        get { return userManager; }
    }

    private readonly SignInManager<AppUser> signInManager;

    public SignInManager<AppUser> SignInManager
    {
        get { return signInManager; }
    }

    private readonly RoleManager<IdentityRole> roleManager;

    public RoleManager<IdentityRole> RoleManager
    {
        get { return roleManager; }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}