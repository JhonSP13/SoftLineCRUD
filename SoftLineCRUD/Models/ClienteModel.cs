using System.ComponentModel.DataAnnotations;

namespace SoftLineCRUD.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o codigo do cliente!")]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage ="Digite o nome do cliente!")]
        public required string Nome { get; set; }
        [Required(ErrorMessage ="Digite a Fantasia do Cliente!")]
        public required string Fantasia { get; set; }
        [Required(ErrorMessage ="Digite o Documento do Cliente!")]
        public int Documento { get; set; }
        [Required(ErrorMessage ="Digite o endereço do Cliente!")]
        public required string Endereco { get; set; }
    }
}
