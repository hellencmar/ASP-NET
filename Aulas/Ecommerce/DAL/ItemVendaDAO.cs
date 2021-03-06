﻿using Ecommerce.Models;
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
            string carrinhoId = Sessao.RetonarCarrinhoId();
            Produto produto = itemVenda.Produto;
            ItemVenda itemVendaDb = ctx.ItensVenda.FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoId && x.CarrinhoId == carrinhoId);
            if (itemVendaDb == null)
            {
                ctx.ItensVenda.Add(itemVenda);
                ctx.SaveChanges();
            }
            else
            {
                AumentarQtdItem(itemVendaDb);
            }
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
                ctx.SaveChanges();
            }
        }
        public static int QtdNoCarrinho()
        {
            string carrinhoID = Sessao.RetonarCarrinhoId();
            int qtd = 0;
            List<ItemVenda> listItemVenda = ctx.ItensVenda.Include("Produto").Where(x => x.CarrinhoId == carrinhoID).ToList();
            foreach (ItemVenda itemVenda in listItemVenda)
            {
                qtd = qtd + itemVenda.Quantidade;
            }
            return qtd;
        }
    }
}