using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models.Academia
{
    public class FichaTreino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        public ICollection<Treino> Treinos { get; set; }
    }
}
