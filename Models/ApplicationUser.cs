using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HotelManager
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El número de identidad es obligatorio.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "El número de identidad debe contener exactamente 13 dígitos.")]
        public string NumeroIdentidad { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }
    }
}
