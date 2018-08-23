using Ecommerce.Models;
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
    }
}