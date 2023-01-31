using Core.Entities;

namespace Core.Interfaces;

public interface IFavouritesRepository
{
    Task<Favourites> GetFavouritesAsync(string favouritesId);
    Task<Favourites> UpdateFavouritesAsync(Favourites favourites);
    Task<bool> DeleteFavouritesAsync(string favouritesId);
}