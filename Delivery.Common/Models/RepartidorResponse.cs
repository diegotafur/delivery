using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Common.Models
{
    public class RepartidorResponse
    {
   
        public int IdRepartidor { get; set; }

        public string Placa { get; set; }

        public ICollection<ViajeResponse> Viajes { get; set; }

        public UsuarioResponse Usuario { get; set; }


    }
}
