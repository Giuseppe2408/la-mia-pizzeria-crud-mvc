using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Validation
{
    public class ValidationParole : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string formValue = (string)value;
            if (formValue != null)
            {
                string[] words = formValue.Split(' ');
                if (words.Length < 5)
                {
                    return new ValidationResult("inserisci almeno 5 parole");
                }
                
            }


            return ValidationResult.Success;
        }

    }
}
