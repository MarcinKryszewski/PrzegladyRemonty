using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesMainViewModel : ViewModelBase
    {
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public ActionsCategoriesMainViewModel(
            INavigationService<ActionsCategoriesEditViewModel> actionsCategoriesEditViewModel,
            INavigationService<ActionsCategoriesAddViewModel> actionsCategoriesAddViewModel,
            INavigationService<ActionsCategoriesDetailsViewModel> actionsCategoriesDetailsViewModel
            )
        {
            NavigateEditCommand = new NavigateCommand<ActionsCategoriesEditViewModel>(actionsCategoriesEditViewModel);
            NavigateAddCommand = new NavigateCommand<ActionsCategoriesAddViewModel>(actionsCategoriesAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<ActionsCategoriesDetailsViewModel>(actionsCategoriesDetailsViewModel);
        }
    }
}
