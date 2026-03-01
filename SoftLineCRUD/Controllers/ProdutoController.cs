using Microsoft.AspNetCore.Mvc;
using SoftLineCRUD.Models;
using SoftLineCRUD.Repository;

namespace SoftLineCRUD.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtoRepository.ListarProdutos();
            return View(produtos);
        }

        public IActionResult AdicionarProduto()
        {
            return View();
        }

        public IActionResult EditarProduto(int Id)
        {
            ProdutoModel produto = _produtoRepository.ListarProdutoPorId(Id);
            return View(produto);
        }

        public IActionResult VisualizarProduto()
        {
            return View();
        }

        public IActionResult ExcluirProduto(int Id)
        {
            ProdutoModel produto = _produtoRepository.ListarProdutoPorId(Id);
            return View(produto);
        }

        public IActionResult ConfirmarExclusao(int Id)
        {
            try
            {
                bool apagado = _produtoRepository.ConfirmarExclusao(Id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir produto!";

                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao excluir produto: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepository.AdicionarProduto(produto);
                    TempData["MensagemSucesso"] = "Produto adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao adicionar produto: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepository.EditarProduto(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar produto: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
