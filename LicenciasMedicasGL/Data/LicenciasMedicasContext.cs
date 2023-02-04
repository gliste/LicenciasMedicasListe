using LicenciasMedicasGL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LicenciasMedicasGL.Data
{
    public class LicenciasMedicasContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public LicenciasMedicasContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region establecer nombres para los Entity Stores

            builder.Entity<IdentityUser<int>>().ToTable("Personas");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");


            #endregion
        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Licencia> Licencias { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Prestadora> Prestadoras { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Visita> Visitas { get; set; }

        public DbSet<Rol> Roles { get; set; }

    }
}
