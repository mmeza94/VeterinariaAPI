using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Models
{
    public partial class Cita
    {
        public int CitaId { get; set; }
        public string Propietario { get; set; }
        public string NombreMascota { get; set; }
        public string Email { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Síntomas { get; set; }
    }
}
