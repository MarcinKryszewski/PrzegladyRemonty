using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Commands.Load;
using PrzegladyRemonty.Features.Transporters.Stores;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersMainViewModel : ViewModelBase, ITransporterUpdate
    {
        private readonly ObservableCollection<Transporter> _transporters;
        private readonly IHost _databaseHost;
        private Transporter _selectedTransporter;
        private readonly SelectedTransporter _transporterStore;
        private readonly IEnumerable<Line> _lines;
        private readonly IEnumerable<Area> _areas;
        private readonly IEnumerable<TransporterType> _transporterTypes;

        public IEnumerable<Transporter> Transporters => _transporters;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand RemoveCommand { get; }

        public Transporter SelectedTransporter
        {
            get => _selectedTransporter;
            set
            {
                _selectedTransporter = value;
                _transporterStore.Transporter = value;
                OnPropertyChanged(nameof(SelectedTransporter));
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public SelectedTransporter SelectedTransporterStore => _transporterStore;
        public bool IsSelected => _selectedTransporter != null;

        public TransportersMainViewModel(
            INavigationService<TransportersEditViewModel> transportersEditViewModel,
            INavigationService<TransportersAddViewModel> transportersAddViewModel,
            INavigationService<TransportersDetailsViewModel> transportersDetailsViewModel,
            IHost database,
            SelectedTransporter selectedTransporter,
            IEnumerable<Line> lines,
            IEnumerable<Area> areas,
            IEnumerable<TransporterType> transporterTypes
            )
        {
            NavigateEditCommand = new NavigateCommand<TransportersEditViewModel>(transportersEditViewModel);
            NavigateAddCommand = new NavigateCommand<TransportersAddViewModel>(transportersAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<TransportersDetailsViewModel>(transportersDetailsViewModel);

            _databaseHost = database;
            _transporters = new ObservableCollection<Transporter>();
            _transporterStore = selectedTransporter;
            _lines = lines;
            _areas = areas;
            _transporterTypes = transporterTypes;

            LoadCommand = new TransportersLoadCommand(this, _databaseHost.Services.GetRequiredService<TransporterProvider>());
            RemoveCommand = new TransportersRemoveCommand(this, _databaseHost.Services.GetRequiredService<TransporterProvider>());

            LoadCommand.Execute(null);
        }

        public void UpdateTransporters(IEnumerable<Transporter> transporters)
        {
            _transporters.Clear();
            foreach (Transporter transporter in transporters)
            {
                transporter.SetArea(_areas.First(a => a.Id == transporter.AreaId));
                transporter.SetType(_transporterTypes.First(t => t.Id == transporter.TransporterTypeId));
                _transporters.Add(transporter);
            }
        }
    }
}
