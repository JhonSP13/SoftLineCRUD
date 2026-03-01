using Microsoft.EntityFrameworkCore;
namespace SoftLineCRUD.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<Models.ClienteModel> Clientes { get; set; }
        public DbSet<Models.ProdutoModel> Produtos { get; set; }
    }
}
