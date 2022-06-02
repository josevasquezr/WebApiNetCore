using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class TareasService : ITareasService
    {
        TareasContext _context;

        public TareasService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Tarea> Get()
        {
            return _context.Tareas.Include(p => p.Categoria);
        }

        public Tarea Get(Guid id)
        {
            Tarea tarea = _context.Tareas
                            .Include(p => p.Categoria)
                            .Include(p => p.Usuario)
                            .FirstOrDefault(p => p.TareaId == id);

            return tarea;
        }

        public List<Tarea> GetPorCategoria(Guid id)
        {
            IEnumerable<Tarea> tareasPorCategorias = from tarea in _context.Tareas
                                                    where tarea.CategoriaId == id
                                                    select tarea;

            return tareasPorCategorias.ToList(); 
        }

        public async Task Save(Tarea tarea)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            Tarea tareaActual = _context.Tareas.Find(id);

            if (tareaActual != null)
            {
                tareaActual.CategoriaId = tarea.CategoriaId;
                tareaActual.UsuarioId = tarea.UsuarioId;
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.FechaHoraRecordatorio = tarea.FechaHoraRecordatorio;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.Recordatorio = tarea.Recordatorio;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            Tarea tareaActual = _context.Tareas.Find(id);

            if (tareaActual != null)
            {
                _context.Remove(tareaActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ITareasService
    {
        IEnumerable<Tarea> Get();
        Tarea Get(Guid id);
        List<Tarea> GetPorCategoria(Guid id);
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);

    }
}