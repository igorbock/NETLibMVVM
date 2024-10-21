using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models.Academia
{
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        public int Repeticao { get; set; }

        [ForeignKey(nameof(Treino))]
        public int IdTreino { get; set; }

        public virtual Treino Treino { get; set; }
    }
}
