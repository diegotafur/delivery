using Delivery.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data
{
    public class DataContext: IdentityDbContext<UsuarioEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RepartidorEntity> Repartidores { get; set; }
        public DbSet<ViajeEntity> Viajes { get; set; }
        public DbSet<DetalleViajeEntity> DetalleViajes { get; set; }
        public DbSet<GrupoUsuarioEntity> GrupoUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RepartidorEntity>().HasIndex(t => t.Placa).IsUnique();
        }
    }
}
