using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }

        public ActionsCategoriesDetailsViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);
        }
    }
}
