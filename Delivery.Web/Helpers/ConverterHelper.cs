using Delivery.Common.Models;
using Delivery.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public RepartidorResponse ToRepartidorResponse(RepartidorEntity repartidorEntity)
        {
            return new RepartidorResponse
            {
                IdRepartidor = repartidorEntity.IdRepartidor,
                Placa = repartidorEntity.Placa,
                Viajes = repartidorEntity.Viajes?.Select(r => new ViajeResponse
                {
                    FechaFin = r.FechaFin,
                    IdViaje = r.IdViaje,
                    Calificacion = r.Calificacion,
                    Comentarios = r.Comentarios,
                    Destino = r.Destino,
                    DestinoLatitud = r.DestinoLatitud,
                    DestinoLongitud = r.DestinoLongitud,
                    FechaInicio = r.FechaInicio,
                    Origen = r.Origen,
                    OrigenLatitud = r.OrigenLatitud,
                    OrigenLongitud = r.OrigenLongitud,
                    DetalleViajes = r.DetalleViajes?.Select(td => new ViajeDetalleResponse
                    {
                        Fecha = td.Fecha,
                        IdDetalleViaje = td.IdDetalleViaje,
                        Latitud = td.Latitud,
                        Longitud = td.Longitud
                    }).ToList(),
                    Usuario = ToUsuarioResponse(r.Usuario)   // el que hace uso
                }).ToList(),
                Usuario = ToUsuarioResponse(repartidorEntity.Usuario) //conductor
            };
        }

        private UsuarioResponse ToUsuarioResponse(UsuarioEntity user)
        {
            if(user == null)
            {
                return null;
            }

            return new UsuarioResponse
            {
                Direccion = user.Direccion,
                Documento = user.Documento,
                Email = user.Email,
                Nombre = user.Nombre,
                Id = user.Id,
                Apellidos = user.Apellidos,
                PhoneNumber = user.PhoneNumber,
                FotoPerfil = user.FotoPerfil,
                TipoUsuario = user.TipoUsuario
            };
        }
    }
}

