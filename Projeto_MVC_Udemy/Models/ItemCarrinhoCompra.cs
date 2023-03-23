using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_LanchesMac_Udemy.Models
{
    [Table("ItemCarrinhoCompra")]
    public class ItemCarrinhoCompra
    {
        public int ItemCarrinhoCompraId { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
