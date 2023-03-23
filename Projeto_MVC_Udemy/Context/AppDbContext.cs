using Microsoft.EntityFrameworkCore;
using Projeto_LanchesMac_Udemy.Models;

namespace Projeto_LanchesMac_Udemy.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<ItemCarrinhoCompra> ItemCarrinhoCompra { get; set; }

    }
}
