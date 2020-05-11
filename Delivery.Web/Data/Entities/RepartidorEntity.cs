using Delivery.Common.Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data.Entities
{
    public class RepartidorEntity
    {
        [Key]
        public int IdRepartidor { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "La {0} deberia ser {1} caracteres. ")]
        [RegularExpression(@"^([A-Za-z]{3}\d{3})$", ErrorMessage = "El campo {0} debe iniciar con tres letras y terminar con tres números.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Placa { get; set; }

        public ICollection<ViajeEntity> Viajes { get; set; }

        public UsuarioEntity Usuario { get; set; }
    }
}
