using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MGQSBreakfast.Models;
using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Entities;
using MGQSBreakfast.Implementation.Repository;
using MGQSBreakfast.Contracts.Services;

namespace MGQSBreakfast.Controllers;

public class BreakfastController : Controller
{
    private readonly IBreakfastService _breakfastservice;
    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastservice = breakfastService;
    }
    // GET: BreakfastController
    public IActionResult GetAll()
    {
        var breakfast = _breakfastservice.GetAllBreakfast();
        return View(breakfast.Data);

    }

    // GET: BreakfastController/Details/5
    public IActionResult Details(int id)
    {
        var breakfast = _breakfastservice.GetBreakfast(id);
        if (breakfast.Status == false)
        {
            ViewBag.Message = breakfast.Message;
            return View();
        }
        return View(breakfast.Data);
    }

    // GET: BreakfastController/Create
    public IActionResult Create()
    {
        return View();
    }
  
    [HttpPost]
    public IActionResult Create(CreateBreakfastViewModel breakfast)
    {
        var breakfasts = _breakfastservice.CreateBreakfast(breakfast);
        if (breakfasts.Status == false)
        {
            ViewBag.Message = breakfasts.Message;
            return View();
        }
        return RedirectToAction("Index");

    }

    // GET: BreakfastController/Edit/5
    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(int id, UpdateBreakfastViewModel updateBreakfastDTO)
    {
        var breakfast = _breakfastservice.UpdateBreakfast(id, updateBreakfastDTO);
        if (breakfast.Status == false)
        {
            ViewBag.Message = breakfast.Message;
            return View();

        }
        return RedirectToAction("Index");
    }

    public IActionResult DeleteBreakfast(int id)
    {
        var breakfast = _breakfastservice.GetBreakfast(id);
        return View(breakfast);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var breakfast = _breakfastservice.DeleteBreakfast(id);
        if (breakfast.Status == false)
        {
            ViewBag.Message = breakfast.Message;
            return View();

        }
        return RedirectToAction("Index");
    }


}

