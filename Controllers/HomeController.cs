using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpSessions.Models;

namespace tpSessions.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("id") = null){
            return View("IniciarSesion");
        }
        BD bd = new BD();
        ViewBag.user = bd.BuscarUsuario(HttpContext.Session.GetString("id"));
        return View();   
    }

    [HttpPost]
    public IActionResult IniciarSesion(string nombreUsuartio, string contraseña)
    {
        BD bd = new BD();
        HttpContext.Session.SetString("id", bd.iniciarSesion(nombreUsuartio, contraseña).ToString());
        if (HttpContext.Session.GetString("id") == "-1"){
            ViewBag.msj = "No existe ese usuario :)";
            return View();
        }
        return RedirectToAction("Index");
    }

    public IActionResult CerrarSesion(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Registrarse(string nombreUsuario, string contraseña, string nombre, string apellido, string tipoUsuario){
        Usuario user = new Usuario(nombreUsuario, contraseña, nombre, apellido, tipoUsuario);
        BD bd = new BD();
        bd.CrearUsuario(user);
        HttpContext.Session.SetString("id", bd.iniciarSesion(nombreUsuario, contraseña).ToString());
        return RedirectToAction("Index");
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
