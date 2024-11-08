using ECommerce.Data.Base;
using ECommerce.Models;
using ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    readonly AppDbContext _context;

    public MoviesService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDetails = await _context.Movies
            .Include(c => c.Cinema)
            .Include(p => p.Producer)
            .Include(m => m.Actors_Movies).ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(n => n.Id == id);

        return movieDetails;
    }

    public async Task<MovieDropdowns> GetMovieDropdownsValuesAsync()
    {
        var response = new MovieDropdowns()
        {
            Actors = await _context.Actors.OrderBy(c => c.FullName).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(c => c.FullName).ToListAsync()
        };

        return response;
    }
}
