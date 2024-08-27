using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models.Academia
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public DateTime Inscricao { get; set; }
    }
}
