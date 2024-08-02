using EntityFrameworkLib.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLib.Models
{
    public class Pessoa : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required]
        [MaxLength(10)]
        public string RG { get; set; }

        [ForeignKey("Endereco")]
        [Browsable(false)]
        public int? IdEndereco { get; set; }

        [Browsable(false)]
        public Endereco Endereco { get; set; }
    }
}
