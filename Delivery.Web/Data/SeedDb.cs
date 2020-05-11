using Delivery.Common.Enumeraciones;
using Delivery.Web.Data.Entities;
using Delivery.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUsuarioHelper _userHelper;
        public SeedDb(DataContext dataContext,IUsuarioHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
           
            await CheckRolesAsync();
            await CheckUserAsync("1", "Diego", "Tafur Obregon", "diegotafurobregon@outlook.com", "930703112", "Av. Tingo Maria ", TipoUsuario.Administrador);
            var repartidor = await CheckUserAsync("2", "Fredy", "Tafur Espinoza", "diegotafurobregon@gmail.com", "999999999", "Calle Luna Calle Sol", TipoUsuario.Repartidor);
            var usuario1 = await CheckUserAsync("3", "Diana", "Tafur Obregon", "diana.tafur@globant.com", "350 634 2747", "Calle Luna Calle Sol", TipoUsuario.Usuario);
            var usuario2 = await CheckUserAsync("4", "Danesa", "Tafur Obregon", "danesa.tafur@globant.com", "350 634 2747", "Calle Luna Calle Sol", TipoUsuario.Usuario);
            await CheckRepartidoresAsync(repartidor, usuario1, usuario2);
              
        }

        private async Task CheckRepartidoresAsync(
            UsuarioEntity repartidor,
            UsuarioEntity usuario1,
            UsuarioEntity usuario2
            )
        {
           
            if (!_dataContext.Repartidores.Any())
            {
                _dataContext.Repartidores.Add(new RepartidorEntity
                {
                    Usuario = repartidor,
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
                        Comentarios = "Puntual y amable",
                        Usuario = usuario1
                    },
                    new ViajeEntity
                    {
                        FechaInicio = DateTime.UtcNow,
                        FechaFin = DateTime.UtcNow.AddMinutes(50),
                        Calificacion = 6.8f,
                        Origen = "Av Los Jazmines 236",
                        Destino = "Av. Venezuela 123",
                        Comentarios = "Puntual y amable",
                        Usuario = usuario2
                    },
                }
                });
                await _dataContext.SaveChangesAsync();
            }
           
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.VerificarRolAsync(TipoUsuario.Administrador.ToString());
            await _userHelper.VerificarRolAsync(TipoUsuario.Repartidor.ToString());
            await _userHelper.VerificarRolAsync(TipoUsuario.Usuario.ToString());
        }

        private async Task<UsuarioEntity> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
    TipoUsuario userType)
        {
            var user = await _userHelper.ObtenerUsuarioPorEmailAsync(email);
            if (user == null)
            {
                user = new UsuarioEntity
                {
                    Nombre = firstName,
                    Apellidos = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Direccion = address,
                    Documento = document,
                    TipoUsuario = userType
                };

                await _userHelper.AgregarUsuarioAsync(user, "123456");
                await _userHelper.AgregarUsuarioPorRolAsync(user, userType.ToString());
            }

            return user;
        }

    }
}
