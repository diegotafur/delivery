using Delivery.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTaxisAsync();
        }

        private async Task CheckTaxisAsync()
        {
            if (_dataContext.Repartidores.Any())
            {
                return;
            }
            _dataContext.Repartidores.Add(new RepartidorEntity
            {
                Placa = "XXX123",
                Viajes = new List<ViajeEntity>
                {
                    new ViajeEntity
                    {
                        FechaInicio = DateTime.UtcNow,
                        FechaFin = DateTime.UtcNow.AddMinutes(30),
                        Calificacion = 4.8f,
                        Origen = "Pasaje Atlantida s/n",
                        Destino = "Av. Santa Rosa - Ancon",
                        Comentarios = "Puntual y amable"
                    },
                    new ViajeEntity
                    {
                        FechaInicio = DateTime.UtcNow,
                        FechaFin = DateTime.UtcNow.AddMinutes(50),
                        Calificacion = 6.8f,
                        Origen = "Av Los Jazmines 236",
                        Destino = "Av. Venezuela 123",
                        Comentarios = "Puntual y amable"
                    },
                }
            });
            await _dataContext.SaveChangesAsync();
        }

    }
}
