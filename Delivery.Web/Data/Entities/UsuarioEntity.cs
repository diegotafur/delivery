using Delivery.Common.Enumeraciones;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Data.Entities
{
    public class UsuarioEntity : IdentityUser
    {

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Documento { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Apellidos { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Direccion { get; set; }

        [Display(Name = "Foto Perfil")]
        public string FotoPerfil { get; set; }

        [Display(Name = "Tipo Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos}";

        public string NombreCompletoConDocumento => $"{Nombre} {Apellidos} - {Documento}";

        public ICollection<RepartidorEntity> Repartidores { get; set; }

        public ICollection<ViajeEntity> Viajes { get; set; }

    }
}
