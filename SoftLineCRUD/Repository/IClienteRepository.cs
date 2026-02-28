using SoftLineCRUD.Models;

namespace SoftLineCRUD.Repository
{
    public interface IClienteRepository
    {
        List<ClienteModel> ListarClientes();
        ClienteModel AdicionarCliente(ClienteModel cliente);
    }
}
