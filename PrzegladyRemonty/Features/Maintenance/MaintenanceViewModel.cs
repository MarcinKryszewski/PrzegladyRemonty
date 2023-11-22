using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IServiceProvider _databaseServices;
        private readonly TransportersListStore _transportersList;
        private readonly TransporterStore _transporter;
        private readonly IHost _maintenanceHost;
        private readonly Brewery _brewery;

        private ObservableCollection<TransporterPart> _transporterParts;
        private ObservableCollection<TransporterAction> _transporterActions;
        private readonly IEnumerable<Transporter> _transporters;
        private readonly IEnumerable<ActionCategory> _actions;
        private readonly IEnumerable<Part> _parts;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MaintenanceViewModel(IHost databaseHost)
        {
            _databaseServices = databaseHost.Services;
            _navigationStore = new NavigationStore();

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _transporterParts = new ObservableCollection<TransporterPart>(GetTransportersParts());
            _transporterActions = new ObservableCollection<TransporterAction>(GetTransporterActions());
            _transporters = GetTransporters();
            _actions = GetActions();
            _parts = GetParts();

            SetTransportersParts();
            SetTransportersActions();

            _brewery = SetBrewery();

            _maintenanceHost = Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<TransportersListStore>();
                    services.AddTransient<TransporterStore>();
                    services.AddSingleton(_transporterParts);
                    services.AddSingleton(_transporterActions);
                    services.AddSingleton(_brewery);

                    services.AddSingleton<TransportersChooseViewModel>();
                    services.AddSingleton<ProductionLineListViewModel>();
                    services.AddSingleton<ActionsListViewModel>();
                    services.AddSingleton<PartsListViewModel>();
                    services.AddSingleton<TransporterCartViewModel>();
                    services.AddSingleton<MaintenanceTransporterStore>();

                    services.AddSingleton(_navigationStore);

                    services.AddSingleton(_databaseServices.GetRequiredService<WorkOrderProvider>());
                    services.AddSingleton(_databaseServices.GetRequiredService<WorkOrderMaintenanceProvider>());
                    services.AddSingleton(_databaseServices.GetRequiredService<MaintenanceProvider>());

                    services.AddTransient((s) => CreateTransportersChooseViewModel(s));
                    services.AddSingleton<CreateViewModel<TransportersChooseViewModel>>((s) => () => s.GetRequiredService<TransportersChooseViewModel>());
                    services.AddSingleton<NavigationService<TransportersChooseViewModel>>((s) =>
                    {
                        return new NavigationService<TransportersChooseViewModel>(
                            s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<CreateViewModel<TransportersChooseViewModel>>()
                        );
                    });

                    services.AddTransient((s) => CreateMaintenanceCreateViewModel(s));
                    services.AddSingleton<CreateViewModel<MaintenanceCreateViewModel>>((s) => () => s.GetRequiredService<MaintenanceCreateViewModel>());
                    services.AddSingleton<NavigationService<MaintenanceCreateViewModel>>((s) =>
                    {
                        return new NavigationService<MaintenanceCreateViewModel>(
                            s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<CreateViewModel<MaintenanceCreateViewModel>>()
                        );
                    });

                    services.AddSingleton<TransporterCartViewModel>();
                })
                .Build();
            _maintenanceHost.Start();

            NavigationService<TransportersChooseViewModel> navigationService = _maintenanceHost.Services.GetRequiredService<NavigationService<TransportersChooseViewModel>>();
            navigationService.Navigate();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private static TransportersChooseViewModel CreateTransportersChooseViewModel(IServiceProvider services)
        {
            return new TransportersChooseViewModel(services);
        }

        private static MaintenanceCreateViewModel CreateMaintenanceCreateViewModel(IServiceProvider services)
        {
            return new MaintenanceCreateViewModel(services);
        }

        private void SetTransportersParts()
        {
            foreach (TransporterPart transporterPart in _transporterParts)
            {
                transporterPart.SetPart(_parts.First(p => p.Id == transporterPart.PartId));
                transporterPart.SetTransporter(_transporters.First(t => t.Id == transporterPart.TransporterId));
            }
        }

        private void SetTransportersActions()
        {
            foreach (TransporterAction transporterAction in _transporterActions)
            {
                transporterAction.SetAction(_actions.First(a => a.Id == transporterAction.ActionId));
                transporterAction.SetTransporter(_transporters.First(t => t.Id == transporterAction.TransporterId));
            }
        }

        private Brewery SetBrewery()
        {
            Brewery brewery = new();
            AddLines(brewery);

            return brewery;
        }

        private void AddLines(Brewery brewery)
        {
            foreach (Line line in GetLines())
            {
                AddAreas(line);
                brewery.AddLine(line);
            }
        }

        private void AddAreas(Line line)
        {
            foreach (Area area in GetAreas().Where(c => c.LineId == line.Id).ToList())
            {
                AddTransporters(area);
                area.SetLine(line);
                line.AddArea(area);
            }
        }

        private void AddTransporters(Area area)
        {
            foreach (Transporter transporter in _transporters.Where(c => c.AreaId == area.Id).ToList())
            {
                transporter.SetType(GetTransportersType().FirstOrDefault(b => b.Id == transporter.TransporterTypeId));

                IEnumerable<TransporterPart> transportersParts = _transporterParts.Where(b => b.TransporterId == transporter.Id);
                IEnumerable<Part> parts = _parts.Where(c => transportersParts.Any(b => b.PartId == c.Id));

                foreach (Part part in parts)
                {
                    transporter.AddPart(part);
                }

                IEnumerable<TransporterAction> transportersActions = _transporterActions.Where(b => b.TransporterId == transporter.Id);
                IEnumerable<ActionCategory> actions = _actions.Where(c => transportersActions.Any(b => b.ActionId == c.Id));

                foreach (ActionCategory action in actions)
                {
                    transporter.AddAction(action);
                }

                area.AddTransporter(transporter);
                transporter.SetArea(area);
            }
        }

        private IEnumerable<Transporter> GetTransporters()
        {
            return _databaseServices.GetRequiredService<TransporterProvider>().GetAll().Result;
        }

        private IEnumerable<Area> GetAreas()
        {
            return _databaseServices.GetRequiredService<AreaProvider>().GetAll().Result;
        }

        private IEnumerable<Line> GetLines()
        {
            return _databaseServices.GetRequiredService<LineProvider>().GetAll().Result;
        }

        private IEnumerable<TransporterType> GetTransportersType()
        {
            return _databaseServices.GetRequiredService<TransporterTypeProvider>().GetAll().Result;
        }

        private IEnumerable<Part> GetParts()
        {
            return _databaseServices.GetRequiredService<PartProvider>().GetAll().Result;
        }

        private IEnumerable<TransporterPart> GetTransportersParts()
        {
            return _databaseServices.GetRequiredService<TransporterPartProvider>().GetAll().Result;
        }

        private IEnumerable<ActionCategory> GetActions()
        {
            IEnumerable<ActionCategory> actionsList = _databaseServices.GetRequiredService<ActionCategoryProvider>().GetAll().Result;
            return actionsList;
        }

        private IEnumerable<TransporterAction> GetTransporterActions()
        {
            IEnumerable<TransporterAction> actionsList = _databaseServices.GetRequiredService<TransporterActionProvider>().GetAll().Result;
            return actionsList;
        }
    }
}
