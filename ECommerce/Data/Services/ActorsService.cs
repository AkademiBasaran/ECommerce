using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

public class ActorsService : EntityBaseRepository<Actor>, IActorsService
{
    readonly AppDbContext _context;

    public ActorsService(AppDbContext context) : base(context)
    {

    }




}
