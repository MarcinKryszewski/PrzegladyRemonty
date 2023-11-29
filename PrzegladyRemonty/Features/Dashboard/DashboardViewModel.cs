using System;
using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;

namespace PrzegladyRemonty.Features.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        private int _openTasks;
        private int _myWorkOrders;
        private IServiceProvider _databaseServices;

        public int OpenTasks
        {
            get => _openTasks;
            set
            {
                _openTasks = value;
                OnPropertyChanged(nameof(OpenTasks));
            }
        }

        public int MyWorkOrders
        {
            get => _myWorkOrders;
            set
            {
                _myWorkOrders = value;
                OnPropertyChanged(nameof(MyWorkOrders));
            }
        }


        public DashboardViewModel(IServiceProvider databaseServices, UserStore user)
        {
            _databaseServices = databaseServices;

            _myWorkOrders = _databaseServices.GetRequiredService<WorkOrderProvider>().CountForUser(user.User.Id);
            _openTasks = _databaseServices.GetRequiredService<MaintenanceProvider>().CountUncompleted();
        }


    }
}
