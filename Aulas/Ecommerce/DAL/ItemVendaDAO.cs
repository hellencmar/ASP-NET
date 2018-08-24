using Ecommerce.Models;
using Ecommerce.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ItemVendaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarItemVenda(ItemVenda itemVenda)
        {
            ctx.ItensVenda.Add(itemVenda);
            ctx.SaveChanges();
        }

        public static List<ItemVenda> BuscarItensVendaPorCarrinhoId()
        {
            string carrinhoId = Sessao.RetonarCarrinhoId();
            return ctx.ItensVenda.Include("Produto").Where(x => x.CarrinhoId.Equals(carrinhoId)).ToList();
        }      
        public static Produto BuscarProdutoPorItemId(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);

            return item.Produto;
        }
        public static ItemVenda BuscarItemVendaPorID(int id)
        {
            ItemVenda itemVenda = ctx.ItensVenda.Find(id);
            return itemVenda;
        }
        public static void AumentarQtdItem(ItemVenda itemVenda)
        {
              ++itemVenda.Quantidade;
                ctx.SaveChanges();         
        }
        public static void DiminuirQtdItem(ItemVenda itemVenda)
        {
            if(itemVenda.Quantidade > 1)
            --itemVenda.Quantidade;
              ctx.SaveChanges();
        }
        public static void RemoverItemVenda(ItemVenda itemVenda)
        {
            if(itemVenda.Quantidade > 1)
            {
                DiminuirQtdItem(itemVenda);
            }
            else if(itemVenda.Quantidade == 1)
            {
                ctx.ItensVenda.Remove(itemVenda);
            }
        }
    }
}