using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Commands.Load;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesMainViewModel : ViewModelBase, ITransporterTypeUpdate
    {
        private readonly ObservableCollection<TransporterType> _transporterTypes;
        private readonly IHost _databaseHost;
        private TransporterType _selectedTransporterType;
        private readonly SelectedTransporterType _transporterTypeStore;

        public IEnumerable<TransporterType> TransporterTypes => _transporterTypes;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand TransporterTypesLoadCommand { get; }
        public ICommand TransporterTypesRemoveCommand { get; }

        public TransporterType SelectedTransporterType
        {
            get => _selectedTransporterType;
            set
            {
                _selectedTransporterType = value;
                _transporterTypeStore.TransporterType = value;
                OnPropertyChanged(nameof(SelectedTransporterType));
                OnPropertyChanged(nameof(IsTransporterTypeSelected));
            }
        }

        public SelectedTransporterType SelectedTransporterTypeStore => _transporterTypeStore;
        public bool IsTransporterTypeSelected => _selectedTransporterType != null;

        public TransporterTypesMainViewModel(
            INavigationService<TransporterTypesEditViewModel> transporterTypesEditViewModel,
            INavigationService<TransporterTypesAddViewModel> transporterTypesAddViewModel,
            INavigationService<TransporterTypesDetailsViewModel> transporterTypesDetailsViewModel,
            SelectedTransporterType selectedTransporterType,
            IHost databaseHost
            )
        {
            NavigateEditCommand = new NavigateCommand<TransporterTypesEditViewModel>(transporterTypesEditViewModel);
            NavigateAddCommand = new NavigateCommand<TransporterTypesAddViewModel>(transporterTypesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<TransporterTypesDetailsViewModel>(transporterTypesDetailsViewModel);

            _databaseHost = databaseHost;
            _transporterTypes = new ObservableCollection<TransporterType>();
            _transporterTypeStore = selectedTransporterType;
            TransporterTypesLoadCommand = new TransporterTypesLoadCommand(this, _databaseHost.Services.GetRequiredService<TransporterTypeProvider>());
            TransporterTypesRemoveCommand = new TransporterTypesRemoveCommand(this, _databaseHost.Services.GetRequiredService<TransporterTypeProvider>());

            TransporterTypesLoadCommand.Execute(null);
        }

        public void UpdateTransporterTypes(IEnumerable<TransporterType> transporterTypes)
        {
            _transporterTypes.Clear();
            foreach (TransporterType transporterType in transporterTypes)
            {
                _transporterTypes.Add(transporterType);
            }
        }
    }
}
