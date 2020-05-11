using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Common.Models
{
    public class ViajeResponse
    {
       
        public int IdViaje { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaInicioLocal => FechaInicio.ToLocalTime();

        public DateTime? FechaFin { get; set; }

        public DateTime? FechaFinLocal => FechaFin?.ToLocalTime();

 
        public string Origen { get; set; }


        public string Destino { get; set; }

        public float Calificacion { get; set; }

        public double OrigenLatitud { get; set; }

        public double OrigenLongitud { get; set; }

        public double DestinoLatitud { get; set; }

        public double DestinoLongitud { get; set; }

        public string Comentarios { get; set; }

        public ICollection<ViajeDetalleResponse> DetalleViajes { get; set; }

        public UsuarioResponse Usuario { get; set; }

    }
}
