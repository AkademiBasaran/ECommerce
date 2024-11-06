using ECommerce.Data.Base;
using ECommerce.Models;
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
}
