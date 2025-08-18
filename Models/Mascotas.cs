namespace Veterinaria_crudcore.Models
{
    public class Mascotas
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string raza { get; set; } = string.Empty;
        public string generoRaza { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
    }
}
