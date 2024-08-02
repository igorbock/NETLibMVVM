using EntityFrameworkLib.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models
{
    public class Endereco : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Rua { get; set; }
        public int? Numero { get; set; }

        [Required, MaxLength(30)]
        public string Cidade { get; set; }

        [Required, MaxLength(2)]
        public string Estado { get; set; }

        [NotMapped]
        public string EnderecoCompleto
        {
            get => $"{Rua}, {(Numero.HasValue ? Numero.ToString() : "S/N")} / {Cidade} - {Estado}";
        }
    }
}
