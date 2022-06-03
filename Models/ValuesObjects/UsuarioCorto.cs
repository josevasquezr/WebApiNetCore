namespace WebAPI.Models.ValuesObjects
{
    public class UsuarioCorto
    {
        public Guid UsuarioId {get; set;}
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto 
        { 
            get { return $"{Nombres} {Apellidos}"; }
        }
    }
}