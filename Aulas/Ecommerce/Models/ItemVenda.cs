using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("ItensVenda")]
    public class ItemVenda
    {
       [Key]
        public int ItemVendaId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public string CarrinhoId { get; set; }
    }
}