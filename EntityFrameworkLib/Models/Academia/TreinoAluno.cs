using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models.Academia
{
    public class TreinoAluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [ForeignKey(nameof(Treino))]
        public int IdTreino { get; set; }

        [ForeignKey(nameof(Aluno))]
        public int IdAluno { get; set; }

        [ForeignKey(nameof(FichaTreino))]
        public int IdFichaTreino { get; set; }

        public virtual Treino Treino { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual FichaTreino FichaTreino { get; set; }
    }
}
