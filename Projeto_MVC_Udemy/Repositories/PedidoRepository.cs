using Projeto_LanchesMac_Udemy.Context;
using Projeto_LanchesMac_Udemy.Models;
using Projeto_LanchesMac_Udemy.Repositories.Interfaces;

namespace Projeto_LanchesMac_Udemy.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var itensCarrinhoCompra = _carrinhoCompra.ItensCarrinhoCompra;

            foreach (var itemCarrinho in itensCarrinhoCompra)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = itemCarrinho.Quantidade,
                    LancheId = itemCarrinho.Lanche.Id,
                    PedidoId = pedido.Id,
                    Preco = itemCarrinho.Lanche.Preco,
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
