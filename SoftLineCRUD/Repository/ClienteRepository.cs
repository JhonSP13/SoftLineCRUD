using SoftLineCRUD.Data;
using SoftLineCRUD.Models;

namespace SoftLineCRUD.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ClienteModel> ListarClientes()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel AdicionarCliente(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }
    }
}