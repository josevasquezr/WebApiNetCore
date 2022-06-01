using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CategoriasService : ICategoriasService
    {
        TareasContext _context;
        public CategoriasService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            Categoria categoriaActual = _context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Peso = categoria.Peso;
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            Categoria categoriaActual = _context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                _context.Remove(categoriaActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriasService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);

    }
}