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

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsMainViewModel : ViewModelBase, IPartUpdate
    {
        private readonly ObservableCollection<Part> _parts;
        private readonly IHost _databaseHost;
        private Part _selectedPart;
        private readonly SelectedPart _partStore;

        public IEnumerable<Part> Parts => _parts;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand PartsLoadCommand { get; }
        public ICommand PartsRemoveCommand { get; }

        public Part SelectedPart
        {
            get => _selectedPart;
            set
            {
                _selectedPart = value;
                _partStore.Part = value;
                OnPropertyChanged(nameof(SelectedPart));
                OnPropertyChanged(nameof(IsPartSelected));
            }
        }

        public SelectedPart SelectedPartStore => _partStore;
        public bool IsPartSelected => _selectedPart != null;

        public PartsMainViewModel(
            INavigationService<PartsEditViewModel> partsEditViewModel,
            INavigationService<PartsAddViewModel> partsAddViewModel,
            INavigationService<PartsDetailsViewModel> partsDetailsViewModel,
            SelectedPart selectedPart,
            IHost databaseHost
            )
        {
            NavigateEditCommand = new NavigateCommand<PartsEditViewModel>(partsEditViewModel);
            NavigateAddCommand = new NavigateCommand<PartsAddViewModel>(partsAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<PartsDetailsViewModel>(partsDetailsViewModel);

            _databaseHost = databaseHost;
            _parts = new ObservableCollection<Part>();
            _partStore = selectedPart;
            PartsLoadCommand = new PartsLoadCommand(this, _databaseHost.Services.GetRequiredService<PartProvider>());
            PartsRemoveCommand = new PartsRemoveCommand(this, _databaseHost.Services.GetRequiredService<PartProvider>());

            PartsLoadCommand.Execute(null);
        }

        public void UpdateParts(IEnumerable<Part> parts)
        {
            _parts.Clear();
            foreach (Part part in parts)
            {
                _parts.Add(part);
            }
        }
    }
}
