using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Errors;
using WebAPI.Exceptions;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[Authorize]
public class CommentsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentsController(
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Comment>>> GetAllComments()
    {
        return Ok(await _unitOfWork.Repository<Comment>().ListAllAsync());
    }
    
    [HttpGet("movies/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<Comment>>> GetCommentsByMovieId(int id)
    {
        return Ok(await _unitOfWork.CommentRepository.GetByMovieIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> AddComment(CommentDto commentDto)
    {
        if (commentDto == null) return BadRequest();
        
        var user = await _unitOfWork.UserManager.FindByEmailFromClaimsPrincipal(User);
        
        var comment = _mapper.Map<Comment>(commentDto);
        comment.DisplayName = user.DisplayName;
        
        _unitOfWork.Repository<Comment>().Add(comment);
        await _unitOfWork.SaveAsync();

        return comment;
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var comment = _unitOfWork.Repository<Comment>().GetByIdAsync(id);
        if (comment == null) throw new AboutCinemaProjectException("Comment not found");

        _unitOfWork.Repository<Comment>().Remove(await comment);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}