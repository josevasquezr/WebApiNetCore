using WebAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.ValuesObjects;
using WebAPI.Contexts;

namespace WebAPI.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly TareasContext _context;
        public UsuariosService(TareasContext context)
        {
            _context = context;
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.Include(u => u.Tareas).ToList();
        }

        public Usuario Get(Guid id)
        {
            IEnumerable<Usuario> usuarios = from usua in _context.Usuarios.Include(u => u.Tareas)
                                            where usua.UsuarioId == id
                                            select usua;

            return usuarios.FirstOrDefault();
        }

        public List<UsuarioCorto> GetUsuariosConNotificacion()
        {
            IEnumerable<UsuarioCorto> usuarios = from usua in _context.Usuarios
                                            where usua.Notificaciones == true
                                            select new UsuarioCorto() { 
                                                    UsuarioId = usua.UsuarioId, 
                                                    Nombres = usua.Nombres, 
                                                    Apellidos = usua.Apellidos 
                                                };

            return usuarios.ToList();
        }

        public async Task Save(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Usuario usuario)
        {
            IEnumerable<Usuario> usuarios = from usua in _context.Usuarios
                                            where usua.UsuarioId == id
                                            select usua;

            if (usuarios.Count() > 0)
            {
                Usuario usua = usuarios.FirstOrDefault();

                usua.Nombres = usuario.Nombres;
                usua.Apellidos = usuario.Apellidos;
                usua.Alias = usuario.Alias;
                usua.correo = usuario.correo;
                usua.Notificaciones = usuario.Notificaciones;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            IEnumerable<Usuario> usuario = from usua in _context.Usuarios
                                           where usua.UsuarioId == id
                                           select usua;

            if (usuario.Count() > 0)
            {
                _context.Usuarios.Remove(usuario.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
        }


    }

    public interface IUsuariosService
    {
        List<Usuario> Get();
        Usuario Get(Guid id);
        List<UsuarioCorto> GetUsuariosConNotificacion();
        Task Save(Usuario usuario);
        Task Update(Guid id, Usuario usuario);
        Task Delete(Guid id);
    }
}