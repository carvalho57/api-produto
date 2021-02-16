using System.ComponentModel.DataAnnotations;

namespace Products.Models {
    public class Category {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracteres")]
        [MaxLength(40, ErrorMessage = "Este campo deve conter entre 3 e 40 caracteres")]
        public string Title { get; set; }
    }
}