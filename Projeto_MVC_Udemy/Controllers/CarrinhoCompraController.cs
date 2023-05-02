using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Projeto_LanchesMac_Udemy.Models;
using Projeto_LanchesMac_Udemy.Repositories.Interfaces;
using Projeto_LanchesMac_Udemy.ViewModels;

namespace Projeto_LanchesMac_Udemy.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.ItensCarrinhoCompra = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        //RedirectToActionResult:
        //302 - Found
        //301 - Moved Permanently
        //307 - Temporary Redirect
        //308 - Permanent Redirect
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId) //também é possível utilizar o tipo IActionResult aqui
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.Id == lancheId);

            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.Id == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
