using AutoMapper;
using Core.Entities;
using WebAPI.DTO;

namespace WebAPI.Helpers;

public class MovieUrlResolver : IValueResolver<Movie, MovieDto, string>
{
    private readonly IConfiguration _config;
    public MovieUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Movie source, MovieDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
        return null;
    }
}