using SoftLineCRUD.Models;

namespace SoftLineCRUD.Repository
{
    public interface IProdutoRepository
    {
        ProdutoModel ListarProdutoPorId(int Id);

        List<ProdutoModel> ListarProdutos();
        ProdutoModel AdicionarProduto(ProdutoModel produto);
        ProdutoModel EditarProduto(ProdutoModel produto);

        bool ConfirmarExclusao(int Id);
    }
}
