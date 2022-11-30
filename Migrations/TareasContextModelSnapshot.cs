﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Contexts;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac23"),
                            Nombre = "Actividades Laborales",
                            Peso = 50
                        },
                        new
                        {
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac24"),
                            Nombre = "Actividades Personales",
                            Peso = 30
                        },
                        new
                        {
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac25"),
                            Nombre = "Actividades Familiares",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac26"),
                            Nombre = "Servicios Públicos",
                            Peso = 80
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaHoraRecordatorio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<bool>("Recordatorio")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac27"),
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac23"),
                            FechaCreacion = new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(2),
                            PrioridadTarea = 1,
                            Recordatorio = false,
                            Titulo = "Revisión de documentación SIISAR",
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01")
                        },
                        new
                        {
                            TareaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac28"),
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac24"),
                            FechaCreacion = new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(26),
                            PrioridadTarea = 0,
                            Recordatorio = false,
                            Titulo = "Ver pelicula Batman en HBO",
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac02")
                        },
                        new
                        {
                            TareaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac29"),
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac25"),
                            FechaCreacion = new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(98),
                            FechaHoraRecordatorio = new DateTime(2022, 12, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            PrioridadTarea = 0,
                            Recordatorio = true,
                            Titulo = "Viaje Roatán",
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac03")
                        },
                        new
                        {
                            TareaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac30"),
                            CategoriaId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac26"),
                            FechaCreacion = new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(282),
                            FechaHoraRecordatorio = new DateTime(2022, 5, 29, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            PrioridadTarea = 2,
                            Recordatorio = true,
                            Titulo = "Pago de energia eléctrica",
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01")
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Notificaciones")
                        .HasColumnType("bit");

                    b.Property<string>("contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01"),
                            Alias = "jvasquez",
                            Apellidos = "Vásquez Ramos",
                            Nombres = "José Javier",
                            Notificaciones = true,
                            contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                            correo = "jvasquez@hotmail.com"
                        },
                        new
                        {
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac02"),
                            Alias = "dvasquez",
                            Apellidos = "Vásquez Ramos",
                            Nombres = "Daniel Isaias",
                            Notificaciones = false,
                            contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                            correo = "dvasquez@hotmail.com"
                        },
                        new
                        {
                            UsuarioId = new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac03"),
                            Alias = "jbaquedano",
                            Apellidos = "Baquedano",
                            Nombres = "Juan Carlos",
                            Notificaciones = true,
                            contrasenia = "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609",
                            correo = "jbaquedano@hotmail.com"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Tarea", b =>
                {
                    b.HasOne("WebAPI.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithMany("Tareas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebAPI.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("WebAPI.Models.Usuario", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
