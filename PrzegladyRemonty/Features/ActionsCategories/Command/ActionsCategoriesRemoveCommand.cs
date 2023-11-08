using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesRemoveCommand : AsyncCommandBase
    {
        private readonly ActionCategoryProvider _partProvider;
        private readonly ActionsCategoriesMainViewModel _actionsCategoriesMainViewModel;
        public ActionsCategoriesRemoveCommand(ActionsCategoriesMainViewModel viewModel, ActionCategoryProvider provider)
        {
            _partProvider = provider;
            _actionsCategoriesMainViewModel = viewModel;
            _actionsCategoriesMainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _actionsCategoriesMainViewModel.IsActionsCategoriesSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            ActionCategory action = _actionsCategoriesMainViewModel.SelectedActionsCategoriesStore.ActionsCategory;
            await action.Delete(_partProvider);
            _actionsCategoriesMainViewModel.ActionsCategoriesLoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ActionsCategoriesMainViewModel.IsActionsCategoriesSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
