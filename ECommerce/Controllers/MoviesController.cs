using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers;

public class MoviesController : Controller
{
    readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(m => m.Cinema);
        return View(allMovies);
    }


    public async Task<IActionResult> Details(int id)
    {
        var movieDetail = await _service.GetMovieByIdAsync(id);
        return View(movieDetail);
    }

    public async Task<IActionResult> Create()
    {
        var movieDropdowns = await _service.GetMovieDropdownsValuesAsync();

        ViewBag.Cinemas = new SelectList(movieDropdowns.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdowns.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdowns.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MovieVM movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        await _service.AddMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}
