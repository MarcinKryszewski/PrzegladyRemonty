using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesAddViewModel : ViewModelBase
    {
        private string _name;
        private string _producent;
        private string _producentNumber;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand NavigateMainCommand { get; }
        public ICommand AddCommand { get; }

        public ActionsCategoriesAddViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);

            AddCommand = new ActionsCategoriesAddCommand(
                this,
                databaseHost.Services.GetRequiredService<ActionCategoryProvider>()
            );
        }
    }
}