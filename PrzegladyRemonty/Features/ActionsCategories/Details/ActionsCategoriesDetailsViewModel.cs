using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public ActionsCategoriesDetailsViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel,
            INavigationService<ActionsCategoriesEditViewModel> actionsCategoriesEditViewModel,
            INavigationService<ActionsCategoriesAddViewModel> actionsCategoriesAddViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);
            NavigateEditCommand = new NavigateCommand<ActionsCategoriesEditViewModel>(actionsCategoriesEditViewModel);
            NavigateAddCommand = new NavigateCommand<ActionsCategoriesAddViewModel>(actionsCategoriesAddViewModel);
        }
    }
}
