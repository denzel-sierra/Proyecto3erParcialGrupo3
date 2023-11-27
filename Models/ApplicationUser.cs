using Microsoft.AspNetCore.Identity;

namespace HotelManager
{
    public class ApplicationUser : IdentityUser
    {
        // Puedes agregar propiedades adicionales según tus necesidades
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
