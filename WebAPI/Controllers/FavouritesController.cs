using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers;

public class FavouritesController : BaseApiController
{
    private readonly IFavouritesRepository _favouritesRepository;
    private readonly IMapper _mapper;

    public FavouritesController(IFavouritesRepository favouritesRepository, IMapper mapper)
    {
        _mapper = mapper;
        _favouritesRepository = favouritesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Favourites>> GetBasketById(string id)
    {
        var favourites = await _favouritesRepository.GetFavouritesAsync(id);

        return Ok(favourites ?? new Favourites(id));
    }

    [HttpPost]
    public async Task<ActionResult<Favourites>> UpdateFavouritesAsync(FavouritesDto favourites)
    {
        var customerFavourites = _mapper.Map<Favourites>(favourites);

        var updatedFavourites = await _favouritesRepository.UpdateFavouritesAsync(customerFavourites);

        return Ok(updatedFavourites);
    }

    [HttpDelete]
    public async Task DeleteFavouritesAsync(string id)
    {
        await _favouritesRepository.DeleteFavouritesAsync(id);
    }
}