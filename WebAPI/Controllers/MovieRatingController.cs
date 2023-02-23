using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[Authorize]
public class MovieRatingController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieRatingController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] MovieRatingDto movieRatingDto)
    {
        var user = await _unitOfWork.UserManager.FindByEmailFromClaimsPrincipal(User);
        
        var rating = _mapper.Map<MovieRating>(movieRatingDto);
        await _unitOfWork.MovieRatingRepository.Vote(rating, user.Id);
        return NoContent();
    }
}