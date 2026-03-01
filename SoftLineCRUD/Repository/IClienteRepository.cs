using SoftLineCRUD.Models;

namespace SoftLineCRUD.Repository
{
    public interface IClienteRepository
    {
        ClienteModel ListarClientePorId(int Id);

        List<ClienteModel> ListarClientes();
        ClienteModel AdicionarCliente(ClienteModel cliente);
        ClienteModel EditarCliente(ClienteModel cliente);

        bool ConfirmarExclusao(int Id);
    }
}
