namespace SoftLineCRUD.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public required string Descricao { get; set; }
        public required string CodBarras { get; set; }
        public float ValorVenda { get; set; }
        public float PesoBruto { get; set; }
        public float PesoLiquido { get; set; }
    }
}
