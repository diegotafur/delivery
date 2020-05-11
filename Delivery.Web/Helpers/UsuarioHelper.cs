using Delivery.Web.Data.Entities;
using Delivery.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Helpers
{
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UsuarioEntity>_signInManager;
        public UsuarioHelper(
            UserManager<UsuarioEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UsuarioEntity> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AgregarUsuarioAsync(UsuarioEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AgregarUsuarioPorRolAsync(UsuarioEntity user, string roleName)
        {
             await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task VerificarRolAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

        }

        public async Task<UsuarioEntity> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> EsUsuarioConEseRolAsync(UsuarioEntity user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username,model.Password,model.RememberMe,false);
        }

        public async Task LogoutAsync()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
