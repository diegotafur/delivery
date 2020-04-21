using Delivery.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RepartidorEntity> Repartidores { get; set; }
        public DbSet<ViajeEntity> Viajes { get; set; }
        public DbSet<DetalleViajeEntity> DetalleViajes { get; set; }

    }
}
