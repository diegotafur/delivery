using Delivery.Web.Data.Entities;
using Delivery.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Helpers
{
    public interface IUsuarioHelper
    {

        Task<UsuarioEntity> ObtenerUsuarioPorEmailAsync(string email);

        Task<IdentityResult> AgregarUsuarioAsync(UsuarioEntity user, string password);

        Task VerificarRolAsync(string roleName);

        Task AgregarUsuarioPorRolAsync(UsuarioEntity user, string roleName);

        Task<bool> EsUsuarioConEseRolAsync(UsuarioEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();



    }
}
