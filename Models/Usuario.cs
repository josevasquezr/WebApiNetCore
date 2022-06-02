namespace WebAPI.Models
{
    public class Usuario
    {
        public Guid UsuarioId {get; set;}
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Alias { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public bool Notificaciones { get; set; }
    }
}