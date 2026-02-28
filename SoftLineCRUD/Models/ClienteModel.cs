namespace SoftLineCRUD.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public required string Nome { get; set; }
        public required string Fantasia { get; set; }
        public int Documento { get; set; }
        public required string Endereco { get; set; }
    }
}
