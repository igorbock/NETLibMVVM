using EntityFrameworkLib.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLib.Models
{
    public class JsonWebToken
    {
        /// <summary>
        /// Identificador ou nome do emissor do token. Geralmente uma URL.
        /// </summary>
        [Required(ErrorMessage = "O campo \"Issuer\" é obrigatório!")]
        public string Issuer { get; set; }

        /// <summary>
        /// Data e hora da emissão do token.
        /// </summary>
        public DateTime? IssuedAt
        {
            get
            {
                if (IssuedDay.HasValue && IssuedTime.HasValue)
                    return new DateTime(IssuedDay.Value.Ticks);

                return null;
            }
        }

        /// <summary>
        /// Dia da emissão do token.
        /// </summary>
        [Required(ErrorMessage = "O campo \"IssuedDay\" é obrigatório!")]
        public DateTime? IssuedDay { get; set; }

        /// <summary>
        /// Hora da emissão do token.
        /// </summary>
        [Required(ErrorMessage = "O campo \"IssuedTime\" é obrigatório!")]
        public DateTime? IssuedTime { get; set; }

        /// <summary>
        /// Data e hora da expiração do token.
        /// </summary>
        public DateTime? Expiration
        {
            get
            {
                if (ExpirationDay.HasValue && ExpirationTime.HasValue)
                    return new DateTime(ExpirationDay.Value.Ticks);

                return null;
            }
        }

        /// <summary>
        /// Dia da expiração do token.
        /// </summary>
        [Required(ErrorMessage = "O campo \"ExpirationDay\" é obrigatório!")]
        [ValidateIssuedExpirationTime(nameof(IssuedDay), nameof(IssuedTime), nameof(ExpirationTime))]
        public DateTime? ExpirationDay { get; set; }

        /// <summary>
        /// Hora da expiração do token.
        /// </summary>
        [Required(ErrorMessage = "O campo \"ExpirationTime\" é obrigatório!")]
        [ValidateIssuedExpirationTime(nameof(IssuedDay), nameof(IssuedTime), nameof(ExpirationDay))]
        public DateTime? ExpirationTime { get; set; }

        /// <summary>
        /// Identificador ou nome do destinatário do token. O destinatário deve corresponder para validação.
        /// </summary>
        [Required(ErrorMessage = "O campo \"Audience\" é obrigatório!")]
        public string Audience { get; set; }

        /// <summary>
        /// Id ou nome do representante do token. Geralmente um usuário.
        /// </summary>
        [Required(ErrorMessage = "O campo \"Subject\" é obrigatório!")]
        public string Subject { get; set; }

        /// <summary>
        /// Claims do token. Pares de chave e valor para indicar permissões ao usuário do token.
        /// </summary>
        public ObservableCollection<Claim> Claims { get; set; }

        /// <summary>
        /// Chave de segurança única que é o valor que o algoritmo vai usar para criptografar o token. Mínimo de 32 caracteres.
        /// </summary>
        //[MinLength(32, ErrorMessage = $"O campo {nameof(Key)} deve ter no mínimo 32 caracteres")]
        [ValidateKeyLength(nameof(Algorithm))]
        [Required(ErrorMessage = "O campo \"Key\" é obrigatório!")]
        public string Key { get; set; }

        /// <summary>
        /// Tipo de algoritmo usado na criptografia. Utilizar a biblioteca Microsoft.IdentityModel.Tokens.SecurityAlgorithms
        /// </summary>
        [Required(ErrorMessage = "Escolha um valor para o campo!")]
        [MinLength(4, ErrorMessage = "Escolha um valor para o campo!")]
        public string Algorithm { get; set; }
    }
}
