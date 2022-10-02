using System;
using Microsoft.EntityFrameworkCore;
using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Persistencia
{    
    public class AppContext : DbContext
    {
       /* public AppContext  (DbContextOptions<AppContext> options) : base(options)
        { 

        }*/

        //poner aqui los modelos
        public DbSet<Entrenador> entrenador{get; set;}
        
        public DbSet<Usuario> usuario{get; set;}
        


        //crear el deContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder
           .UseSqlServer("Server=localhost; user id=sa; password=12345; Initial Catalog=BDFinalProyectos84;");            
            }
        }      

    }
}