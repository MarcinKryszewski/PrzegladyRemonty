using System.Windows.Input;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesAddViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public ActionsCategoriesAddViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel,
            INavigationService<ActionsCategoriesEditViewModel> actionsCategoriesEditViewModel,
            INavigationService<ActionsCategoriesDetailsViewModel> actionsCategoriesDetailsViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);
            NavigateEditCommand = new NavigateCommand<ActionsCategoriesEditViewModel>(actionsCategoriesEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<ActionsCategoriesDetailsViewModel>(actionsCategoriesDetailsViewModel);
        }
    }
}
