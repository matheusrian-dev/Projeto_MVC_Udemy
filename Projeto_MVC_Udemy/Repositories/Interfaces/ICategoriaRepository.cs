using Projeto_LanchesMac_Udemy.Models;

namespace Projeto_LanchesMac_Udemy.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
