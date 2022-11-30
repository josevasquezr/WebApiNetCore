using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using System.Linq;
using WebAPI.Contexts;

namespace WebAPI.Services
{
    public class CategoriasService : ICategoriasService
    {
        TareasContext _context;
        public CategoriasService(TareasContext context)
        {
            _context = context;
        }

        public List<Categoria> Get()
        {
            return _context.Categorias.ToList();
        }

        public Categoria Get(Guid id)
        {
            Categoria categoria = _context.Categorias.Find(id);
            
            return categoria;
        }

        public List<String> GetAllNames()
        {
            IEnumerable<String> nombres = (from categoria in _context.Categorias
                                            select categoria.Nombre)
                                            .Distinct();

            return nombres.ToList(); 
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
        List<Categoria> Get();
        Categoria Get(Guid id);
        List<String> GetAllNames();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);

    }
}