using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasMainViewModel : ViewModelBase
    {
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }

        public AreasMainViewModel(INavigationService<AreasEditViewModel> areasEditViewModel)
        {
            NavigateEditCommand = new NavigateCommand<AreasEditViewModel>(areasEditViewModel);
        }
    }
}
