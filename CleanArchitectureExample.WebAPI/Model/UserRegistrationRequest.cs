using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureExample.WebAPI.Model
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Nimi on pakollinen.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Sähköpostiosoite on pakollinen.")]
        [EmailAddress(ErrorMessage = "Sähköpostiosoite ei ole kelvollinen.")]
         public required string Email {  get; set; }
    }
}
