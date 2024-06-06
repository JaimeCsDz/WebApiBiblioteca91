using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi91.Context
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options): base(options) 
        { 
            
        }

        //modelos
        public DbSet<Usuario> Usaurios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor>Autores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario 
                { 
                    PkUsuario = 1,
                    Nombre = "Jaime",
                    User = "UsuarioYo",
                    Password = "password",
                    FkRol = 1
                }
            );

            //Insertar en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
              new Rol
              {
                  PkRol = 1,
                  Nombre = "SA",
              }
          );
        }



    }
}
