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

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesMainViewModel : ViewModelBase, IActionCategoryUpdate
    {
        private readonly ObservableCollection<ActionCategory> _actionsCategories;
        private readonly IHost _databaseHost;
        private ActionCategory _selectedActionsCategories;
        private readonly SelectedActionCategory _partStore;

        public IEnumerable<ActionCategory> ActionsCategories => _actionsCategories;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand ActionsCategoriesLoadCommand { get; }
        public ICommand ActionsCategoriesRemoveCommand { get; }

        public ActionCategory SelectedActionsCategories
        {
            get => _selectedActionsCategories;
            set
            {
                _selectedActionsCategories = value;
                _partStore.ActionsCategory = value;
                OnPropertyChanged(nameof(SelectedActionsCategories));
                OnPropertyChanged(nameof(IsActionsCategoriesSelected));
            }
        }

        public SelectedActionCategory SelectedActionsCategoriesStore => _partStore;
        public bool IsActionsCategoriesSelected => _selectedActionsCategories != null;

        public ActionsCategoriesMainViewModel(
            INavigationService<ActionsCategoriesEditViewModel> actionsCategoriesEditViewModel,
            INavigationService<ActionsCategoriesAddViewModel> actionsCategoriesAddViewModel,
            INavigationService<ActionsCategoriesDetailsViewModel> actionsCategoriesDetailsViewModel,
            SelectedActionCategory selectedActionsCategories,
            IHost databaseHost
            )
        {
            NavigateEditCommand = new NavigateCommand<ActionsCategoriesEditViewModel>(actionsCategoriesEditViewModel);
            NavigateAddCommand = new NavigateCommand<ActionsCategoriesAddViewModel>(actionsCategoriesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<ActionsCategoriesDetailsViewModel>(actionsCategoriesDetailsViewModel);

            _databaseHost = databaseHost;
            _actionsCategories = new ObservableCollection<ActionCategory>();
            _partStore = selectedActionsCategories;
            ActionsCategoriesLoadCommand = new ActionsCategoriesLoadCommand(this, _databaseHost.Services.GetRequiredService<ActionCategoryProvider>());
            ActionsCategoriesRemoveCommand = new ActionsCategoriesRemoveCommand(this, _databaseHost.Services.GetRequiredService<ActionCategoryProvider>());

            ActionsCategoriesLoadCommand.Execute(null);
        }

        public void UpdateActions(IEnumerable<ActionCategory> actions)
        {
            _actionsCategories.Clear();
            foreach (ActionCategory action in actions)
            {
                _actionsCategories.Add(action);
            }
        }
    }
}
