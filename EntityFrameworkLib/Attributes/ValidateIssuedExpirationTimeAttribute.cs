using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntityFrameworkLib.Attributes
{
    /// <summary>
    /// Compara os valores de IssuedAt e Expiration
    /// </summary>
    public class ValidateIssuedExpirationTimeAttribute : ValidationAttribute
    {
        private string _issuedDateOnly { get; }
        private string _issuedTimeOnly { get; }
        private string _expirationTimeOrDate { get; }

        public ValidateIssuedExpirationTimeAttribute(
            string issuedDateOnly,
            string issuedTimeOnly,
            string expirationTimeOrDate)
        {
            _issuedDateOnly = issuedDateOnly;
            _issuedTimeOnly = issuedTimeOnly;
            _expirationTimeOrDate = expirationTimeOrDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var issuedDateOnlyInfo = validationContext.ObjectType.GetRuntimeProperty(_issuedDateOnly);
            if (issuedDateOnlyInfo == null)
                return new ValidationResult($"A propridade '{_issuedDateOnly}' não existe");

            var issuedTimeOnlyInfo = validationContext.ObjectType.GetRuntimeProperty(_issuedTimeOnly);
            if (issuedTimeOnlyInfo == null)
                return new ValidationResult($"A propridade '{_issuedTimeOnly}' não existe");

            var expirationTimeOrDateInfo = validationContext.ObjectType.GetRuntimeProperty(_expirationTimeOrDate);
            if (expirationTimeOrDateInfo == null)
                return new ValidationResult($"A propridade '{_expirationTimeOrDate}' não existe");

            //var isExpirationTime = DateTime.TryParse(expirationTimeOrDateInfo.GetValue(validationContext.ObjectInstance, null).ToString(), out DateTime valorTimeOnly);
            var isExpirationDate = DateTime.TryParse(expirationTimeOrDateInfo.GetValue(validationContext.ObjectInstance, null).ToString(), out DateTime valorDateOnly);
            //var issuedTime = DateTime.Parse(issuedTimeOnlyInfo.GetValue(validationContext.ObjectInstance, null).ToString());
            var issuedDate = DateTime.Parse(issuedDateOnlyInfo.GetValue(validationContext.ObjectInstance, null).ToString());

            DateTime dateTimeIssued = new DateTime(issuedDate.Year, issuedDate.Month, issuedDate.Day, issuedDate.Hour, issuedDate.Minute, issuedDate.Second);
            //DateTime dateTimeExpiration = new DateTime();
            //if (isExpirationDate)
            //{
            //    var valorPropriedadeTimeOnly = DateTime.Parse(value.ToString());
            //    dateTimeExpiration = new DateTime(valorDateOnly, valorPropriedadeTimeOnly);
            //}

            var valorIssuedAtEhMaiorQueExpiration = dateTimeIssued > valorDateOnly.Date;//dateTimeExpiration;
            if (valorIssuedAtEhMaiorQueExpiration)
                //return new ValidationResult($"O valor do '{nameof(dateTimeExpiration)}' é menor ou igual ao '{nameof(dateTimeIssued)}'!");
                return new ValidationResult($"O valor do '{nameof(valorDateOnly.Date)}' é menor ou igual ao '{nameof(dateTimeIssued)}'!");
            else
                        return null;
        }
    }
}
