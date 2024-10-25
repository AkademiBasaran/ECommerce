using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

public class ProducersController : Controller
{
    readonly AppDbContext _context;

    public ProducersController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allProducers = await _context.Producers.ToListAsync();
        return View(allProducers);
    }
}
