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
            return _context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            Tarea tareaActual = _context.Tareas.Find(id);

            if (tareaActual != null)
            {
                tareaActual.CategoriaId = tarea.CategoriaId;
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.FechaHoraRecordatorio = tarea.FechaHoraRecordatorio;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.Recordatorio = tarea.Recordatorio;
                tareaActual.Resumen = tarea.Resumen;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            Tarea tareaActual = _context.Tareas.Find(id);

            if (tareaActual != null)
            {
                _context.Tareas.Remove(tareaActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ITareasService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);

    }
}