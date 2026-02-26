using Microsoft.AspNetCore.Mvc;

namespace SoftLineCRUD.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarCliente()
        {
            return View();
        }

        public IActionResult EditarCliente()
        {
            return View();
        }

        public IActionResult VisualizarCliente()
        {
            return View();
        }

        public IActionResult ExcluirCliente()
        {
            return View();
        }
    }
}
