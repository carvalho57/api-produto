using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(0.1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]        
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]        
        //Propriedade de navegação
        public Category Category { get; set; }
    }
}
