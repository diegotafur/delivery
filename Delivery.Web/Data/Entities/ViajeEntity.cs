using Delivery.Common.Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data.Entities
{
    public class ViajeEntity
    {
        [Key]
        public int IdViaje { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime FechaInicio { get; set; }

        public DateTime FechaInicioLocal => FechaInicio.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? FechaFin { get; set; }

        public DateTime? FechaFinLocal => FechaFin?.ToLocalTime();

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Origen { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Destino { get; set; }

        public float Calificacion { get; set; }

        public double OrigenLatitud { get; set; }

        public double OrigenLongitud { get; set; }

        public double DestinoLatitud { get; set; }

        public double DestinoLongitud { get; set; }

        public string Comentarios { get; set; }

        //este campo define la relacion
        public RepartidorEntity Repartidor { get; set; }

        public ICollection<DetalleViajeEntity> DetalleViajes { get; set; }

        public UsuarioEntity Usuario { get; set; }
    }
}
