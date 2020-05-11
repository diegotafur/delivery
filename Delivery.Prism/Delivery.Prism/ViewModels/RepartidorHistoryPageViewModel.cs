using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Delivery.Prism.ViewModels
{
    public class RepartidorHistoryPageViewModel : ViewModelBase
    {
        public RepartidorHistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Mis Deliverys";
        }
    }
}
