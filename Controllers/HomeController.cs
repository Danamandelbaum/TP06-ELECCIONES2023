using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_Elecciones2023.Models;

namespace TP06_Elecciones2023.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var partidos = BD.listarPartidos();
        ViewBag.partidos = partidos;
        return View("Index");
    }

    public IActionResult verDetallePartido(int idPartido)
    {
        var datosPartido = BD.verInfoPartido(idPartido);
        ViewBag.datosPartido = datosPartido;
        return View("verDetallePartido");
    }

       public IActionResult verDetalleCandidato(int idCandidato)
    {
        var datosCandidato = BD.verInfoPartido(idCandidato);
        ViewBag.datosCandidato = datosCandidato;
        return View("verDetallePartido");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
