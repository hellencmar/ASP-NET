﻿using System;
using System.Web;

namespace Ecommerce.Utils
{
    public class Sessao
    {
        private static string NOME_SESSAO = "CarrinhoId";
        public static string RetonarCarrinhoId()
        {
            if (HttpContext.Current.Session[NOME_SESSAO] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSAO] = guid.ToString();
            }
            return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }
    }
}