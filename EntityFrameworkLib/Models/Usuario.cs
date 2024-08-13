using EntityFrameworkLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models
{
    public class Usuario : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Nome { get; set; }

        [Required, MaxLength(30)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Senha { get; set; }
    }
}
