using ECommerce.Data.Services;
using Microsoft.AspNetCore.Mvc;

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
        return View();
    }
}
