using Microsoft.AspNetCore.Mvc;
using SoftLineCRUD.Models;
using SoftLineCRUD.Repository;

namespace SoftLineCRUD.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepository.ListarClientes();
            return View(clientes);
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

        [HttpPost]
        public IActionResult AdicionarCliente(ClienteModel cliente)
        {
            _clienteRepository.AdicionarCliente(cliente);
            return RedirectToAction("Index");
        }
    }
}
