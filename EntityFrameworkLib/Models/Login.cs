using EntityFrameworkLib.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models
{
    public class Login : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        public string Token { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
