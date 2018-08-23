using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(CategoriaDAO.RetornarCategorias());
        }
        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível adicionar uma categoria com o mesmo nome!");
                    return View(categoria);
                }
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult RemoverCategoria(int id)
        {
            CategoriaDAO.RemoverCategoria(id);
            return RedirectToAction("Index", "Categoria");
        }

        public ActionResult AlterarCategoria(int id)
        {
            return View(CategoriaDAO.BuscarCategoriaPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoriaAlterada)
        {
            Categoria categoriaOriginal = CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.CategoriaId);

            categoriaOriginal.Nome = categoriaAlterada.Nome;
            categoriaOriginal.Descricao = categoriaAlterada.Descricao;

            if (ModelState.IsValid)
            {
                if (CategoriaDAO.AlterarCategoria(categoriaOriginal))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar uma categoria com o mesmo nome!");
                    return View(categoriaOriginal);
                }
            }
            else
            {
                return View(categoriaOriginal);
            }
        }
    }
}