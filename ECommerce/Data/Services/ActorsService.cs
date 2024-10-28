using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class ActorsService : IActorsService
{
    readonly AppDbContext _context;

    public ActorsService(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Actor>> GetAllAsync() => await _context.Actors.ToListAsync();

    public async Task AddAsync(Actor actor)
    {
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        Actor actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        if (actor is not null)
        {
            return actor;
        }

        return new Actor();
    }
    public async Task<Actor> UpdateAsync(Actor newActor)
    {
        _context.Actors.Update(newActor);
        await _context.SaveChangesAsync();
        return newActor;
    }

    public async Task DeleteAsync(int id)
    {
        Actor actor = _context.Actors.FirstOrDefault(x => x.Id == id);
        if (actor is not null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }

}
