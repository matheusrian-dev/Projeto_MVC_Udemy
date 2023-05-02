using Microsoft.AspNetCore.Mvc;
using Projeto_LanchesMac_Udemy.Models;
using Projeto_LanchesMac_Udemy.ViewModels;

namespace Projeto_LanchesMac_Udemy.Components
{
    //Uma classe ViewComponent deve ser pública, não aninhada e não abstrata
    //Também deve expor o método público InvokeAsync;
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            //var itens = new List<ItemCarrinhoCompra>() //Teste com itens fictícios
            //{
            //    new ItemCarrinhoCompra(),
            //    new ItemCarrinhoCompra()
            //};

            _carrinhoCompra.ItensCarrinhoCompra = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }
    }
}
