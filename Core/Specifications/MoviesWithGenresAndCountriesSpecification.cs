using Core.Entities;

namespace Core.Specifications;

public class MoviesWithGenresAndCountriesSpecification : BaseSpecification<Movie>
{
    public MoviesWithGenresAndCountriesSpecification(MovieSpecParams movieParams) : base(x => 
        (string.IsNullOrEmpty(movieParams.Search) || x.Title.ToLower().Contains(movieParams.Search)) &&
        (!movieParams.CountryId.HasValue || x.MovieCountryId == movieParams.CountryId) &&
        (!movieParams.GenreId.HasValue || x.MovieGenreId == movieParams.GenreId)
    )
    {
        AddInclude(x => x.MovieCountryId);
        AddInclude(x => x.MovieGenreId);
        AddOrderBy(x => x.Title);
        ApplyPaging(movieParams.PageSize * (movieParams.PageIndex - 1), movieParams.PageSize);

        if (!string.IsNullOrEmpty(movieParams.Sort))
        {
            switch (movieParams.Sort)
            {
                case "yearAsc":
                    AddOrderBy(p => p.Year);
                    break;
                case "yearDesc":
                    AddOrderByDescending(p => p.Year);
                    break;
                default:
                    AddOrderBy(n => n.Title);
                    break;
            }
        }
    }

    public MoviesWithGenresAndCountriesSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.MovieCountry);
        AddInclude(x => x.MovieGenre);
    }
}