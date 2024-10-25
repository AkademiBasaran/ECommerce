using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();
        return View(allActors);
    }


    public async Task<IActionResult> Create()
    {
        return View();
    }


    //[Bind("Id,FullName,Bio,ProfilePictureUrl")]
    [HttpPost]
    public async Task<IActionResult> Create(Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        var actorDetail = await _service.GetByIdAsync(id);
        if (actorDetail is null)
        {
            return View("Empty");
        }

        return View(actorDetail);
    }
}
