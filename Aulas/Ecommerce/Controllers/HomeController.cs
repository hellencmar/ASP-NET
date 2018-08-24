using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
          
            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();
            if (id == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            

            return View(ProdutoDAO.BuscarProdutosPorCategoria(id));
        }

        public ActionResult DetalheProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                Produto = produto,
                Quantidade = 1,
                Preco = produto.Preco,
                Data = DateTime.Now,
                CarrinhoId = Sessao.RetonarCarrinhoId()
            };
            ItemVendaDAO.CadastrarItemVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.BuscarItensVendaPorCarrinhoId());
        }
        public ActionResult AumentarQtd(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorID(id);
            ItemVendaDAO.AumentarQtdItem(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }
        public ActionResult DiminuirQtd(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorID(id);
            ItemVendaDAO.DiminuirQtdItem(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }
       
        public ActionResult RemoverItemVenda(int id)
        {
            ItemVenda itemVenda = ItemVendaDAO.BuscarItemVendaPorID(id);
            ItemVendaDAO.RemoverItemVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }
    }
}