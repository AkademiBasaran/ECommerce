using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class ProducersController : Controller
{
    readonly IProducersService _service;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allProducers = await _service.GetAllAsync();
        return View(allProducers);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        var productorDetail = await _service.GetByIdAsync(id);
        if (productorDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(productorDetail);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var productorDetail = await _service.GetByIdAsync(id);
        if (productorDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(productorDetail);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        await _service.UpdateAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var productorDetail = await _service.GetByIdAsync(id);
        if (productorDetail.Id == 0)
        {
            return View("_NotFound");
        }

        return View(productorDetail);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        await _service.DeleteAsync(Id);
        return RedirectToAction(nameof(Index));
    }
}
