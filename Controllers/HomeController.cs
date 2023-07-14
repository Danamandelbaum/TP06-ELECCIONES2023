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
        ViewBag.listarPartidos = BD.listarPartidos();
        return View("Index");
    }

    public IActionResult verDetallePartido(int idPartido)
    {
        ViewBag.datosPartido = BD.verInfoPartido(idPartido);
        ViewBag.listarCandidatos = BD.listarCandidatos(idPartido);
        return View("verDetallePartido");
    }

       public IActionResult verDetalleCandidato(int idCandidato)
    {
        ViewBag.datosCandidato = BD.verInfoCandidato(idCandidato);
        return View("verDetalleCandidato");
    }

        public IActionResult agregarCandidato(int idPartido)
    {
        ViewBag.IdPartido = idPartido;
        return View("agregarCandidato");
    }

    [HttpPost] public IActionResult guardarCandidato(Candidato can)
    {
        BD.agregarCandidato(can);
        return RedirectToAction("verDetallePartido", new { idPartido = can.idPartido });
    }

    IActionResult eliminarCandidato(int idCandidato, int idPartido)
    {
        BD.eliminarCandidato(idCandidato);
        return RedirectToAction("verDetallePartido", new { idPartido = idPartido });
    }

    public IActionResult Elecciones()
    {
        return View("Elecciones");
    }

    public IActionResult Creditos()
    {
        return View("Creditos");
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
