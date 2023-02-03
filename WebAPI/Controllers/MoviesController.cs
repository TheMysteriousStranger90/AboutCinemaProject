using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Errors;
using WebAPI.Helpers;

namespace WebAPI.Controllers;

public class MoviesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MoviesController(
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Cached(600)]
    [HttpGet]
    public async Task<ActionResult<Pagination<MovieDto>>> GetMovies(
        [FromQuery] MovieSpecParams movieParams)
    {
        var spec = new MoviesWithGenresAndCountriesSpecification(movieParams);
        var countSpec = new MoviesWithFiltersForCountSpecification(movieParams);

        var totalItems = await _unitOfWork.Repository<Movie>().CountAsync(countSpec);
        var movies = await _unitOfWork.Repository<Movie>().ListAsync(spec);

        var data = _mapper.Map<IReadOnlyList<MovieDto>>(movies);

        return Ok(new Pagination<MovieDto>(movieParams.PageIndex,
            movieParams.PageSize, totalItems, data));
    }

    [Cached(600)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieDto>> GetMovie(int id)
    {
        var spec = new MoviesWithGenresAndCountriesSpecification(id);

        var movie = await _unitOfWork.Repository<Movie>().GetEntityWithSpec(spec);

        if (movie == null) return NotFound(new ApiResponse(404));

        return _mapper.Map<Movie, MovieDto>(movie);
    }

    [Cached(600)]
    [HttpGet("genres")]
    public async Task<ActionResult<IReadOnlyList<MovieGenre>>> GetMovieGenres()
    {
        return Ok(await _unitOfWork.Repository<MovieGenre>().ListAllAsync());
    }

    [Cached(600)]
    [HttpGet("countries")]
    public async Task<ActionResult<IReadOnlyList<MovieCountry>>> GetMovieCountries()
    {
        return Ok(await _unitOfWork.Repository<MovieCountry>().ListAllAsync());
    }
}