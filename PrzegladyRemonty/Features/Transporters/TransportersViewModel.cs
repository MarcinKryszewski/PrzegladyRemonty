using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Commands.Load;
using PrzegladyRemonty.Features.Transporters.Stores;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersViewModel : ViewModelBase, ILineUpdate, IAreaUpdate, IPartUpdate, ITransporterTypeUpdate
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly SelectedTransporter _selectedTransporter;
        private readonly ObservableCollection<Line> _lines;
        private readonly ObservableCollection<Area> _areas;
        private readonly ObservableCollection<Part> _parts;
        private readonly ObservableCollection<TransporterType> _transporterTypes;
        private readonly ICommand _loadLines;
        private readonly ICommand _loadAreas;
        private readonly ICommand _loadParts;
        private readonly ICommand _loadTransporterTypes;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public TransportersViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _databaseHost = databaseHost;
            IServiceProvider databaseServices = _databaseHost.Services;

            INavigationService<TransportersMainViewModel> TransportersMainNavigationService = CreateTransportersMainNavigationService();

            _selectedTransporter = new SelectedTransporter();

            _lines = new ObservableCollection<Line>();
            _areas = new ObservableCollection<Area>();
            _parts = new ObservableCollection<Part>();
            _transporterTypes = new ObservableCollection<TransporterType>();

            _loadLines = new LinesLoadCommand(this, databaseServices.GetRequiredService<LineProvider>());
            _loadAreas = new AreasLoadCommand(this, databaseServices.GetService<AreaProvider>());
            _loadParts = new PartsLoadCommand(this, databaseServices.GetRequiredService<PartProvider>());
            _loadTransporterTypes = new TransporterTypesLoadCommand(this, databaseServices.GetRequiredService<TransporterTypeProvider>());

            _loadLines.Execute(null);
            _loadAreas.Execute(null);
            _loadParts.Execute(null);
            _loadTransporterTypes.Execute(null);

            TransportersMainNavigationService.Navigate();
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<TransportersMainViewModel> CreateTransportersMainNavigationService()
        {
            return new DefaultNavigationService<TransportersMainViewModel>
            (
                _navigationStore,
                () => new TransportersMainViewModel(
                    CreateTransportersEditNavigationService(),
                    CreateTransportersAddNavigationService(),
                    CreateTransportersDetailsNavigationService(),
                    _databaseHost,
                    _selectedTransporter,
                    _lines,
                    _areas,
                    _transporterTypes)
            );
        }
        private INavigationService<TransportersAddViewModel> CreateTransportersAddNavigationService()
        {
            return new DefaultNavigationService<TransportersAddViewModel>
            (
                _navigationStore,
                () => new TransportersAddViewModel(
                    CreateTransportersMainNavigationService(),
                    _databaseHost,
                    _lines,
                    _areas,
                    _transporterTypes)
            );
        }
        private INavigationService<TransportersDetailsViewModel> CreateTransportersDetailsNavigationService()
        {
            return new DefaultNavigationService<TransportersDetailsViewModel>
            (
                _navigationStore,
                () => new TransportersDetailsViewModel(
                    CreateTransportersMainNavigationService(),
                    _databaseHost
                )
            );
        }
        private INavigationService<TransportersEditViewModel> CreateTransportersEditNavigationService()
        {
            return new DefaultNavigationService<TransportersEditViewModel>
            (
                _navigationStore,
                () => new TransportersEditViewModel(CreateTransportersMainNavigationService(), _databaseHost,
                _lines, _areas, _transporterTypes, _selectedTransporter)
            );
        }

        public void UpdateLines(IEnumerable<Line> lines)
        {
            _lines.Clear();
            foreach (Line line in lines)
            {
                _lines.Add(line);
            }

        }
        public void UpdateAreas(IEnumerable<Area> areas)
        {
            _areas.Clear();
            foreach (Area area in areas)
            {
                area.SetLine(_lines.First(l => l.Id == area.LineId));
                _areas.Add(area);
            }
        }
        public void UpdateParts(IEnumerable<Part> parts)
        {
            _parts.Clear();
            foreach (Part part in parts)
            {
                _parts.Add(part);
            }
        }
        public void UpdateTransporterTypes(IEnumerable<TransporterType> transporterTypes)
        {
            _transporterTypes.Clear();
            foreach (TransporterType type in transporterTypes)
            {
                _transporterTypes.Add(type);
            }
        }
    }
}
