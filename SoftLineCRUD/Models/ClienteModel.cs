namespace SoftLineCRUD.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public int Documento { get; set; }
        public string Endereco { get; set; }
    }
}
