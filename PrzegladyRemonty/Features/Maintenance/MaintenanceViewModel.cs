using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IServiceProvider _databaseServices;
        private readonly TransportersListStore _transporters;
        private readonly TransporterStore _transporter;
        private readonly IHost _maintenanceHost;
        private readonly Brewery _brewery;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MaintenanceViewModel(IHost databaseHost)
        {
            _databaseServices = databaseHost.Services;
            _navigationStore = new NavigationStore();

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _brewery = SetBrewery();

            _maintenanceHost = Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<TransportersListStore>();
                    services.AddTransient<TransporterStore>();
                    services.AddSingleton(_brewery);

                    services.AddSingleton<TransportersChooseViewModel>();
                    services.AddSingleton<ProductionLineListViewModel>();
                    services.AddSingleton<ActionsListViewModel>();
                    services.AddSingleton<PartsListViewModel>();
                    services.AddSingleton<TransporterCartViewModel>();
                    services.AddSingleton<MaintenanceTransporterStore>();

                    services.AddSingleton(_navigationStore);
                    services.AddTransient((s) => CreateTransportersChooseViewModel(s));
                    services.AddSingleton<CreateViewModel<TransportersChooseViewModel>>((s) => () => s.GetRequiredService<TransportersChooseViewModel>());
                    services.AddSingleton<NavigationService<TransportersChooseViewModel>>((s) =>
                    {
                        return new NavigationService<TransportersChooseViewModel>(
                            s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<CreateViewModel<TransportersChooseViewModel>>()
                        );
                    });

                    services.AddSingleton<TransporterCartViewModel>();
                })
                .Build();
            _maintenanceHost.Start();

            //_transporter = _maintenanceHost.Services.GetRequiredService<TransporterStore>();

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
            foreach (Transporter transporter in GetTransporters().Where(c => c.AreaId == area.Id).ToList())
            {
                transporter.SetType(GetTransportersType().FirstOrDefault(b => b.Id == transporter.TransporterTypeId));

                IEnumerable<TransporterPart> transportersParts = GetTransportersParts().Where(b => b.Transporter == transporter.Id);
                IEnumerable<Part> parts = GetParts().Where(c => transportersParts.Any(b => b.Part == c.Id));

                foreach (var part in parts)
                {
                    transporter.AddPart(part);
                }

                IEnumerable<TransporterAction> transportersActions = GetTransporterActions().Where(b => b.Transporter == transporter.Id);
                IEnumerable<ActionCategory> actions = GetActions().Where(c => transportersActions.Any(b => b.Action == c.Id));

                foreach (var action in actions)
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
            IEnumerable<ActionCategory> someList = _databaseServices.GetRequiredService<ActionCategoryProvider>().GetAll().Result;
            return someList;
        }

        private IEnumerable<TransporterAction> GetTransporterActions()
        {
            IEnumerable<TransporterAction> someList = _databaseServices.GetRequiredService<TransporterActionProvider>().GetAll().Result;
            return someList;
        }
    }
}
