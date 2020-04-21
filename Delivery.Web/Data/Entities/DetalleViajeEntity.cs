using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data.Entities
{
    public class DetalleViajeEntity
    {
        [Key]
        public int IdDetalleViaje { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        public DateTime FechaLocal => Fecha.ToLocalTime();

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public ViajeEntity Viaje { get; set; }

    }
}
