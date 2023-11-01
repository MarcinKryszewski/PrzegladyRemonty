using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Areas
{

    public class AreasRemoveCommand : AsyncCommandBase
    {
        private AreasMainViewModel _areasMainViewModel;
        private AreaProvider _areaProvider;

        public AreasRemoveCommand(AreasMainViewModel areasMainViewModel, AreaProvider areaProvider)
        {
            _areasMainViewModel = areasMainViewModel;
            _areaProvider = areaProvider;
            _areasMainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _areasMainViewModel.IsSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Area area = _areasMainViewModel.SelectedAreaStore.Area;
            await area.Delete(_areaProvider);
            _areasMainViewModel.LoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AreasMainViewModel.IsSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
