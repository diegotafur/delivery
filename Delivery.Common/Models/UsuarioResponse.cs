using Delivery.Common.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Common.Models
{
    public class UsuarioResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Documento { get; set; }


        public string Nombre { get; set; }


        public string Apellidos { get; set; }

 
        public string Direccion { get; set; }

        public string FotoPerfil { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos}";

        public string NombreCompletoConDocumento => $"{Nombre} {Apellidos} - {Documento}";


    }
}
