using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categorias = this.getCategorias();
            List<Tarea> tareas = this.getTareas();

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);
                categoria.HasData(categorias);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Property(p => p.Recordatorio);
                tarea.Property(p => p.FechaHoraRecordatorio);
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareas);
            });
        }

        private List<Categoria> getCategorias()
        {
            List<Categoria> categorias = new List<Categoria>(){
                new Categoria(){
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac23"),
                    Nombre = "Actividades Laborales",
                    Peso = 50
                },
                new Categoria(){
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac24"),
                    Nombre = "Actividades Personales",
                    Peso = 30
                },
                new Categoria(){
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac25"),
                    Nombre = "Actividades Familiares",
                    Peso = 20
                },
                new Categoria(){
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac26"),
                    Nombre = "Servicios Públicos",
                    Peso = 80
                }
            };

            return categorias;
        }

        private List<Tarea> getTareas()
        {
            List<Tarea> tareas = new List<Tarea>(){
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac27"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac23"),
                    Titulo = "Revisión de documentación SIISAR",
                    PrioridadTarea = Prioridad.Media,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = false
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac28"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac24"),
                    Titulo = "Ver pelicula Batman en HBO",
                    PrioridadTarea = Prioridad.Baja,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = false
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac29"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac25"),
                    Titulo = "Viaje Roatán",
                    PrioridadTarea = Prioridad.Baja,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = true,
                    FechaHoraRecordatorio = DateTime.Parse("01-12-2022 17:00:00")
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac30"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac26"),
                    Titulo = "Pago de energia eléctrica",
                    PrioridadTarea = Prioridad.Alta,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = true,
                    FechaHoraRecordatorio = DateTime.Parse("29-05-2022 14:00:00")
                }
            };

            return tareas;
        }
    }
}