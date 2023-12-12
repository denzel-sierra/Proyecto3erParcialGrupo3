using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Habitacion
    {
        public Guid IDHabitacion { get; set; }

        [Required(ErrorMessage = "El campo Numero es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Numero debe ser un número positivo.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El campo IDTipoHabitacion es obligatorio.")]
        public Guid IDTipoHabitacion { get; set; }

        [Required(ErrorMessage = "El campo Tarifa es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "La Tarifa debe ser un número positivo.")]
        public decimal Tarifa { get; set; }

        public bool Disponibilidad { get; set; }

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; }

        // Relación de navegación
        [Required(ErrorMessage = "El campo TipoHabitacion es obligatorio.")]
        public TipoHabitacion TipoHabitacion { get; set; }

        [NotMapped]
        public string DisponibilidadTexto { get; set; }
    }
}
