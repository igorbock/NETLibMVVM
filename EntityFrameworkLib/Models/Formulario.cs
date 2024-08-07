using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Diretorio { get; set; }
    }
}
