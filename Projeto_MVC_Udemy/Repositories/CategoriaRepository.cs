using Projeto_LanchesMac_Udemy.Context;
using Projeto_LanchesMac_Udemy.Models;
using Projeto_LanchesMac_Udemy.Repositories.Interfaces;

namespace Projeto_LanchesMac_Udemy.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
