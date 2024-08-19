using EntityFrameworkLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models
{
    public class Usuario : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required, MaxLength(255)]
        public string HashSenha { get; set; }

        [Required]
        public byte[] Salt { get; set; }
    }
}
