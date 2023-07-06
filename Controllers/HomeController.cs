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

        public IActionResult agregarCandidato(int idPartido)
    {
        ViewBag.IdPartido = idPartido;
        return View("agregarCandidato");
    }

    [HttpPost] IActionResult guardarCandidato(Candidato can)
    {
        BD.agregarCandidato(can);
        return RedirectToAction("VerDetallePartido", new { idPartido = can.idPartido });
        return View("guardarCandidato");
    }

    IActionResult eliminarCandidato(int idCandidato, int idPartido)
    {
        BD.eliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido });
        return View(eliminarCandidato);
    }

    IActionResult elecciones()
    {
        return View("elecciones");
    }

    IActionResult creditos()
    {
        return View("creditos");
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
