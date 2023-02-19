namespace VeterinariaAPI.Models
{
    public class CitaDtoInsert
    {
        
        public string Propietario { get; set; }
        public string NombreMascota { get; set; }
        public string Email { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Síntomas { get; set; }
    }
}
