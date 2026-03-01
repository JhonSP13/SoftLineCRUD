using SoftLineCRUD.Data;
using SoftLineCRUD.Models;

namespace SoftLineCRUD.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProdutoModel ListarProdutoPorId(int Id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == Id);
        }
        public ProdutoModel EditarProduto(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarProdutoPorId(produto.Id);

            if (produtoDB == null) throw new Exception("Houve um erro na atualização do produto!");

            produtoDB.CodigoProduto = produto.CodigoProduto;
            produtoDB.Descricao = produto.Descricao;
            produtoDB.CodBarras = produto.CodBarras;
            produtoDB.ValorVenda = produto.ValorVenda;
            produtoDB.PesoBruto = produto.PesoBruto;
            produtoDB.PesoLiquido = produto.PesoLiquido;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();
            return produtoDB;
        }

        public List<ProdutoModel> ListarProdutos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel AdicionarProduto(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public bool ConfirmarExclusao(int Id)
        {
            ProdutoModel produtoDB = ListarProdutoPorId(Id);
            if (produtoDB == null) throw new Exception("Houve um erro na exclusão do produto!");
            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}