using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using Application.Services;

namespace cajero.Controllers
{
    public class CajeroController : Controller
    {
        private DispensadorService dispensadorService;
        public CajeroController()
        {
            dispensadorService = new DispensadorService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult configuracion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult configuracion(ConfiguracionViewModel vm)
        {
            dispensadorService.modoDispension(vm);
            return RedirectToRoute(new {controller = "cajero", Action = "retiro"  });
        }
        public IActionResult retiro() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult retiro(RetiroVewModel vm)
        {
            dispensadorService.retirar(vm);
            return RedirectToRoute(new { controller = "cajero", Action = "Total" });
        }
        public IActionResult Total()
        {
            return View(dispensadorService.getAll());
        }
    }
}
