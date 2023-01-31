using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Repositories;

public class FavouritesRepository : IFavouritesRepository
{
    private readonly IDatabase _database;
    
    public FavouritesRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }
    
    public async Task<Favourites> GetFavouritesAsync(string favouritesId)
    {
        var data = await _database.StringGetAsync(favouritesId);

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Favourites>(data);
    }

    public async Task<Favourites> UpdateFavouritesAsync(Favourites favourites)
    {
        var created = await _database.StringSetAsync(favourites.Id, JsonSerializer.Serialize(favourites),
            TimeSpan.FromDays(30));

        if (!created) return null;

        return await GetFavouritesAsync(favourites.Id);
    }

    public async Task<bool> DeleteFavouritesAsync(string favouritesId)
    {
        return await _database.KeyDeleteAsync(favouritesId);
    }
}