using System;

namespace EntityFrameworkLib.Models.DTOs
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime Nascimento { get; set; }
        public int IdEndereco { get; set; }
        public string Endereco { get; set; }
    }
}
