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

        public IActionResult EditarCliente(int Id)
        {
            ClienteModel cliente = _clienteRepository.ListarClientePorId(Id);
            return View(cliente);
        }

        public IActionResult ExcluirCliente(int Id)
        {
            ClienteModel cliente = _clienteRepository.ListarClientePorId(Id);
            return View(cliente);
        }

        public IActionResult ConfirmarExclusao(int Id)

        {
            try
            {
                bool apagado = _clienteRepository.ConfirmarExclusao(Id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir cliente!";

                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao excluir cliente: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult AdicionarCliente(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.AdicionarCliente(cliente);
                    TempData["MensagemSucesso"] = "Cliente adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao adicionar cliente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.EditarCliente(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar cliente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}