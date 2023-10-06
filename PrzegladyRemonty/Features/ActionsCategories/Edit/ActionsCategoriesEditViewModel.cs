using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesEditViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public ActionsCategoriesEditViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel,
            INavigationService<ActionsCategoriesAddViewModel> actionsCategoriesAddViewModel,
            INavigationService<ActionsCategoriesDetailsViewModel> actionsCategoriesDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);
            NavigateAddCommand = new NavigateCommand<ActionsCategoriesAddViewModel>(actionsCategoriesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<ActionsCategoriesDetailsViewModel>(actionsCategoriesDetailsViewModel);
        }
    }
}
