using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome da categoria")]
        public string Nome { get; set; }

        [Display(Name = "Descrição da categoria")]
        public string Descricao { get; set; }
    }
}