using Microsoft.AspNetCore.Identity;

namespace HotelManager
{
    public class ApplicationUser : IdentityUser
    {
        public string NumeroIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
