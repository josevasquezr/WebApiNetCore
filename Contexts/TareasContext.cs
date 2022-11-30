using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Contexts
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categorias = getCategorias();
            List<Tarea> tareas = getTareas();
            List<Usuario> usuarios = getUsuarios();

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.ToTable("Usuario");
                usuario.HasKey(p => p.UsuarioId);
                usuario.Property(p => p.Nombres).IsRequired().HasMaxLength(200);
                usuario.Property(p => p.Apellidos).IsRequired().HasMaxLength(200);
                usuario.Property(p => p.Alias).IsRequired(false).HasMaxLength(15);
                usuario.Property(p => p.correo).IsRequired().HasMaxLength(200);
                usuario.Property(p => p.contrasenia).IsRequired();
                usuario.Property(p => p.Notificaciones).IsRequired();
                usuario.Ignore(p => p.NombreCompleto);
                usuario.HasData(usuarios);
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso).IsRequired();
                categoria.HasData(categorias);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.HasOne(p => p.Usuario).WithMany(p => p.Tareas).HasForeignKey(p => p.UsuarioId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(300);
                tarea.Property(p => p.PrioridadTarea).IsRequired();
                tarea.Property(p => p.FechaCreacion).IsRequired();
                tarea.Property(p => p.Recordatorio).IsRequired();
                tarea.Property(p => p.FechaHoraRecordatorio).IsRequired(false);
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareas);
            });
        }

        private List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>(){
                new Usuario(){
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac01"),
                    Nombres = "José Javier",
                    Apellidos = "Vásquez Ramos",
                    Alias = "jvasquez",
                    correo = "jvasquez@hotmail.com",
                    contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                    Notificaciones = true
                },
                new Usuario(){
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac02"),
                    Nombres = "Daniel Isaias",
                    Apellidos = "Vásquez Ramos",
                    Alias = "dvasquez",
                    correo = "dvasquez@hotmail.com",
                    contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                    Notificaciones = false
                },
                new Usuario(){
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac03"),
                    Nombres = "Juan Carlos",
                    Apellidos = "Baquedano",
                    Alias = "jbaquedano",
                    correo = "jbaquedano@hotmail.com",
                    contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                    Notificaciones = true
                }
            };

            return usuarios;
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
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac01"),
                    Titulo = "Revisión de documentación SIISAR",
                    PrioridadTarea = Prioridad.Media,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = false
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac28"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac24"),
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac02"),
                    Titulo = "Ver pelicula Batman en HBO",
                    PrioridadTarea = Prioridad.Baja,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = false
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac29"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac25"),
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac03"),
                    Titulo = "Viaje Roatán",
                    PrioridadTarea = Prioridad.Baja,
                    FechaCreacion = DateTime.Now,
                    Recordatorio = true,
                    FechaHoraRecordatorio = DateTime.Parse("01-12-2022 17:00:00")
                },
                new Tarea(){
                    TareaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac30"),
                    CategoriaId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac26"),
                    UsuarioId = Guid.Parse("c88ff4bc-6a99-48ee-95f5-848fc205ac01"),
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