using System.Data.Entity;

namespace Ecommerce.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEcommerce") { }

        //Mapear as classes que vão virar tabela no banco
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItemVenda> ItensVenda { get; set; }
    }
}