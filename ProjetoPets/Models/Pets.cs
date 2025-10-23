using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPets.Models {
    public class Pets {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "A Espécie é obrigatória.")]
        public string Especie { get; set; }


        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        [StringLength(1)]
        [RegularExpression("^[MmFf]$", ErrorMessage = "O Sexo deve ser 'M' (Macho) ou 'F' (Fêmea).")]
        public string Sexo { get; set; }


        [Required(ErrorMessage = "A Idade é obrigatória.")]
        [Range(0, 100, ErrorMessage = "A idade não pode ser negativa e deve ser um valor razoável (0-100).")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "O Peso é obrigatório.")]
        public decimal Peso { get; set; }


        [Required(ErrorMessage = "A raça é obrigatória.")]
        public string Raca { get; set; }

    }
}
