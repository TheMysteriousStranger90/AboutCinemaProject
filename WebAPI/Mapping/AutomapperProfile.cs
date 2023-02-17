using AutoMapper;
using Core.Entities;
using WebAPI.DTO;
using WebAPI.Helpers;

namespace WebAPI.Mapping;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(d => d.MovieCountry, o => o.MapFrom(s => s.MovieCountry.Name))
            .ForMember(d => d.MovieGenre, o => o.MapFrom(s => s.MovieGenre.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<MovieUrlResolver>());
        
        CreateMap<FavouritesDto, Favourites>();
        CreateMap<FavouriteFilmDto, FavouriteFilm>();
        
        CreateMap<CommentDto, Comment>().ReverseMap();
        CreateMap<MovieRatingDto, MovieRating>().ReverseMap();

    }
}