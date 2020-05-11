using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Common.Models
{
    public class ViajeDetalleResponse
    {

        public int IdDetalleViaje { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaLocal => Fecha.ToLocalTime();

        public double Latitud { get; set; }

        public double Longitud { get; set; }

    }
}
