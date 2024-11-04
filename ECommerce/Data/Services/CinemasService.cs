using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
{
    readonly AppDbContext _context;

    public CinemasService(AppDbContext context) : base(context)
    {

    }




}
