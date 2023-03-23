using Projeto_LanchesMac_Udemy.Models;

namespace Projeto_LanchesMac_Udemy.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
