using System.ComponentModel.DataAnnotations;

namespace SoftLineCRUD.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o codigo do Produto!")]
        public int CodigoProduto { get; set; }
        [Required(ErrorMessage = "Digite a descrição do Produto!")]
        public required string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o codigo de Barras!")]
        public required string CodBarras { get; set; }
        [Required(ErrorMessage = "Digite o valor de venda!")]
        public float ValorVenda { get; set; }
        [Required(ErrorMessage = "Digite o peso bruto do produto!")]
        public float PesoBruto { get; set; }
        [Required(ErrorMessage = "Digite o peso liquido do produto!")]
        public float PesoLiquido { get; set; }
    }
}
