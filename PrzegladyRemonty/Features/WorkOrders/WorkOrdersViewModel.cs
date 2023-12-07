using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Features.WorkOrders.Stores;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;
using System;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrdersViewModel : ViewModelBase
    {
        private readonly IServiceProvider _databaseServices;
        private readonly IHost _workOrdersHost;
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public WorkOrdersViewModel(IServiceProvider databaseServices, IServiceProvider userServices)
        {
            _databaseServices = databaseServices;
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _workOrdersHost = Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(_navigationStore);

                    services.AddSingleton(userServices.GetRequiredService<UserStore>());
                    services.AddSingleton(new SelectedWorkOrder());

                    services.AddSingleton(_databaseServices.GetRequiredService<WorkOrderProvider>());
                    services.AddSingleton(_databaseServices.GetRequiredService<MaintenanceProvider>());
                    services.AddSingleton(_databaseServices.GetRequiredService<WorkOrderMaintenanceProvider>());
                    services.AddSingleton(_databaseServices.GetRequiredService<PersonProvider>());

                    services.AddTransient((s) => CreateWorkOrdersListViewModel(s));
                    services.AddSingleton<CreateViewModel<WorkOrdersListViewModel>>((s) => () => s.GetRequiredService<WorkOrdersListViewModel>());
                    services.AddSingleton<NavigationService<WorkOrdersListViewModel>>((s) =>
                    {
                        return new NavigationService<WorkOrdersListViewModel>(
                            s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<CreateViewModel<WorkOrdersListViewModel>>()
                        );
                    });

                    services.AddTransient((s) => CreateWorkOrdersConfirmViewModel(s));
                    services.AddSingleton<CreateViewModel<WorkOrdersConfirmViewModel>>((s) => () => s.GetRequiredService<WorkOrdersConfirmViewModel>());
                    services.AddSingleton<NavigationService<WorkOrdersConfirmViewModel>>((s) =>
                    {
                        return new NavigationService<WorkOrdersConfirmViewModel>(
                            s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<CreateViewModel<WorkOrdersConfirmViewModel>>()
                        );
                    });
                })
                .Build();
            _workOrdersHost.Start();

            NavigationService<WorkOrdersListViewModel> navigationService = _workOrdersHost.Services.GetRequiredService<NavigationService<WorkOrdersListViewModel>>();
            navigationService.Navigate();
        }

        private static WorkOrdersListViewModel CreateWorkOrdersListViewModel(IServiceProvider services)
        {
            return new WorkOrdersListViewModel(services);
        }

        private static WorkOrdersConfirmViewModel CreateWorkOrdersConfirmViewModel(IServiceProvider services)
        {
            return new WorkOrdersConfirmViewModel(services);
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
