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
        public ClienteModel ListarClientePorId(int Id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == Id);
        }
        public ClienteModel EditarCliente(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarClientePorId(cliente.Id);

            if (clienteDB == null) throw new Exception("Houve um erro na atualização do cliente!");

            clienteDB.CodigoCliente = cliente.CodigoCliente;
            clienteDB.Nome = cliente.Nome;
            clienteDB.Fantasia = cliente.Fantasia;
            clienteDB.Documento = cliente.Documento;
            clienteDB.Endereco = cliente.Endereco;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();
            return clienteDB;
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

        public bool ConfirmarExclusao(int Id)
        {
            ClienteModel clienteDB = ListarClientePorId(Id);
            if (clienteDB == null) throw new Exception("Houve um erro na exclusão do cliente!");
            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}