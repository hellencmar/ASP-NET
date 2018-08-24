using Ecommerce.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.Include("Categoria").ToList();
        }
        public static List<Produto> BuscarProdutosPorCategoria(int? id)
        {
            return ctx.Produtos.Include("Categoria").Where(x => x.Categoria.CategoriaId == id).ToList();
        }
        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static void RemoverProduto(int id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();
        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static bool AlterarProduto(Produto produto)
        {
            if (ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome) && x.ProdutoId != produto.ProdutoId) == null)
            {
                ctx.Entry(produto).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}