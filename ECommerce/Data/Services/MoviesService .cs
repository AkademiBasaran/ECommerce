using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    readonly AppDbContext _context;

    public MoviesService(AppDbContext context) : base(context)
    {

    }
}
