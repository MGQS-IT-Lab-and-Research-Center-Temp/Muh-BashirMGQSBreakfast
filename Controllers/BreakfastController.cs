using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MGQSBreakfast.Models;
using MGQSBreakfast.Context;
using MGQSBreakfast.Entities;
using MGQSBreakfast.Implementation.Repository;

namespace MGQSBreakfast.Controllers;

public class BreakfastController : Controller
{
    private readonly ILogger<BreakfastController> _logger;
    private readonly ApplicationDbContext _context;

    public BreakfastController(ILogger<BreakfastController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult GetAll()
    {
        var breakfasts = _context.Breakfasts.ToList();
        return View(breakfasts);
    }

    public IActionResult Breakfast()
    {
        return View();
    }

    public IActionResult Create(Breakfast breakfast)
    {
        if (ModelState.IsValid)
        {
            var obj = new Breakfast();
            obj.Name = breakfast.Name;
            obj.Description = breakfast.Description;
            obj.StartDateTime = breakfast.StartDateTime;
            obj.EndDateTime = breakfast.EndDateTime;
            _context.Breakfasts.Add(obj);
            _context.SaveChanges();
        }
        //ModelState.Clear();
        return View("Create");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

