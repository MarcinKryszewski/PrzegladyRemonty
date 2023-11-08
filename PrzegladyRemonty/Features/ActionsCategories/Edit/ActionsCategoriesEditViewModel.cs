using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesEditViewModel : ViewModelBase
    {
        private readonly int _id;
        private string _name;
        private string _producent;
        private string _producentNumber;

        public int Id => _id;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Producent
        {
            get => _producent;
            set
            {
                _producent = value;
                OnPropertyChanged(nameof(Producent));
            }
        }
        public string ProducentNumber
        {
            get => _producentNumber;
            set
            {
                _producentNumber = value;
                OnPropertyChanged(nameof(ProducentNumber));
            }
        }

        public ICommand NavigateMainCommand { get; }
        public ICommand EditCommand { get; }


        public ActionsCategoriesEditViewModel(
            INavigationService<ActionsCategoriesMainViewModel> actionsCategoriesMainViewModel,
            SelectedActionCategory selectedActionsCategories,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<ActionsCategoriesMainViewModel>(actionsCategoriesMainViewModel);

            ActionCategory part = selectedActionsCategories.ActionsCategory;
            _id = part.Id;
            _name = part.Name;

            EditCommand = new ActionsCategoriesEditCommand(this, databaseHost.Services.GetRequiredService<ActionCategoryProvider>());
        }
    }
}