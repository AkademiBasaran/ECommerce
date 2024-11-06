using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
    Task<Movie> GetMovieByIdAsync(int id);
}
