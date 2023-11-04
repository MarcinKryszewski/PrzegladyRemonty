using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsRemoveCommand : AsyncCommandBase
    {
        private readonly PartProvider _partProvider;
        private readonly PartsMainViewModel _partsMainViewModel;
        public PartsRemoveCommand(PartsMainViewModel partsMainViewModel, PartProvider partProvider)
        {
            _partProvider = partProvider;
            _partsMainViewModel = partsMainViewModel;
            _partsMainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _partsMainViewModel.IsPartSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Part part = _partsMainViewModel.SelectedPartStore.Part;
            await part.Delete(_partProvider);
            _partsMainViewModel.PartsLoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PartsMainViewModel.IsPartSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
