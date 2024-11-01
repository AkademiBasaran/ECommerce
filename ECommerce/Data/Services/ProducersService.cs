using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

public class ProducersService : EntityBaseRepository<Producer>, IProducersService
{
    readonly AppDbContext _context;

    public ProducersService(AppDbContext context) : base(context)
    {

    }
}
