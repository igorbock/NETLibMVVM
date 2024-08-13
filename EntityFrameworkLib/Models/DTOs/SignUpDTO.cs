namespace EntityFrameworkLib.Models.DTOs
{
    public class SignUpDTO
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
