using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Delivery.Web.Data.Entities
{
    public class GrupoUsuarioEntity
    {
        [Key]
        public int IdGrupoUsuario { get; set; }

        public UsuarioEntity Usuario { get; set; }

        public ICollection<UsuarioEntity> Usuarios { get; set; }


    }
}
