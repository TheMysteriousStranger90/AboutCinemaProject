using Core.Entities;

namespace Core.Specifications;

public class MoviesWithFiltersForCountSpecification : BaseSpecification<Movie>
{ 
    public MoviesWithFiltersForCountSpecification(MovieSpecParams movieParams)  : base(x => 
        (string.IsNullOrEmpty(movieParams.Search) || x.Title.ToLower().Contains(movieParams.Search)) &&
        (!movieParams.CountryId.HasValue || x.MovieCountryId == movieParams.CountryId) &&
        (!movieParams.GenreId.HasValue || x.MovieGenreId == movieParams.GenreId))
    {
            
    }
}