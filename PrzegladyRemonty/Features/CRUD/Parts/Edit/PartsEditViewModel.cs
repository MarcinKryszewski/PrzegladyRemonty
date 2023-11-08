using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsEditViewModel : ViewModelBase
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


        public PartsEditViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel,
            SelectedPart selectedPart,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);

            Part part = selectedPart.Part;
            _id = part.Id;
            _name = part.Name;
            _producent = part.Producent;
            _producentNumber = part.ProducentNumber;

            EditCommand = new PartsEditCommand(this, databaseHost.Services.GetRequiredService<PartProvider>());
        }
    }
}