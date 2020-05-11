using Delivery.Common.Models;
using ImTools;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Delivery.Prism.ViewModels
{
    public class RepartidorMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public RepartidorMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icono = "ic_motorcycle",
                    NombrePagina = "HomePage",
                    Titulo = "Nuevo Delivery"
                },
                new Menu
                {
                    Icono = "ic_motorcycle",
                    NombrePagina = "RepartidorHistoryPage",
                    Titulo = "Mi Historial"
                },
                new Menu
                {
                    Icono = "ic_motorcycle",
                    NombrePagina = "GroupPage",
                    Titulo = "Administrar Grupo"
                },
                new Menu
                {
                    Icono = "ic_motorcycle",
                    NombrePagina = "ModifyUserPage",
                    Titulo = "Modificar Usuario"
                },
                new Menu
                {
                    Icono = "ic_motorcycle",
                    NombrePagina = "ReportPage",
                    Titulo = "Reportar un Incidente"
                },
                new Menu
                {
                    Icono = "ic_exit_to_app",
                    NombrePagina = "LoginPage",
                    Titulo = "Log in"
                }

            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icono = m.Icono,
                    NombrePagina = m.NombrePagina,
                    Titulo = m.Titulo
                }).ToList());
        }

    }
}
