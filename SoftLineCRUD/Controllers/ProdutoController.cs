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
            _produtoRepository.ConfirmarExclusao(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            _produtoRepository.AdicionarProduto(produto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarProduto(ProdutoModel produto)
        {
            _produtoRepository.EditarProduto(produto);
            return RedirectToAction("Index");
        }
    }
}
