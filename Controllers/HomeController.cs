﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Netflix.Models;

namespace Netflix.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ReadMoviesService readMoviesService = new ReadMoviesService();
        List<MovieModel> movies = readMoviesService.ReadMovies(6);
        
        
        return Json(new {all_movies=movies});
        // return View(movies);
    }

    public IActionResult Privacy()
    {
        return Json(new {foo="bar", baz="Blech"});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
