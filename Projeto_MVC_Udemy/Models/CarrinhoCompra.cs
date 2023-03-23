using Projeto_LanchesMac_Udemy.Context;

namespace Projeto_LanchesMac_Udemy.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<ItemCarrinhoCompra> ItensCarrinhoCompra { get; set; }

        public static CarrinhoCompra GetCarrinho (IServiceProvider services)
        {
            //define a sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var itemCarrinhoCompra = _context.ItemCarrinhoCompra.SingleOrDefault(s => s.Lanche.Id == lanche.Id && s.CarrinhoCompraId == CarrinhoCompraId);
            if(itemCarrinhoCompra == null)
            {
                itemCarrinhoCompra = new ItemCarrinhoCompra
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.ItemCarrinhoCompra.Add(itemCarrinhoCompra);
            }
            else
            {
                itemCarrinhoCompra.Quantidade++;
            }
            _context.SaveChanges();

        }

        public void RemoverDoCarrinho(Lanche lanche)
        {
            var itemCarrinhoCompra = _context.ItemCarrinhoCompra.SingleOrDefault(s => s.Lanche.Id == lanche.Id && s.CarrinhoCompraId == CarrinhoCompraId);
            if(itemCarrinhoCompra != null)
            {
                if(itemCarrinhoCompra.Quantidade > 1)
                {
                    itemCarrinhoCompra.Quantidade--;
                }
                else
                {
                    _context.ItemCarrinhoCompra.Remove(itemCarrinhoCompra);
                }
            }
            _context.SaveChanges();
        }
    }
}
