using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models.Academia
{
    public class Treino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ForeignKey(nameof(FichaTreino))]
        public int IdFichaTreino { get; set; }

        public ICollection<Exercicio> Exercicios { get; set; }

        public virtual FichaTreino FichaTreino { get; set; }
    }
}
