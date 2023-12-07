using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Features.WorkOrders.Stores;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.WorkOrders
{
    public class WorkOrdersConfirmViewModel : ViewModelBase
    {
        private ObservableCollection<Models.Maintenance> _maintenances;
        private string _dateText;
        private Person _person;

        public Person Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
            }
        }
        public IEnumerable<Person> Persons { get; }
        public IEnumerable<Models.Maintenance> Maintenances => _maintenances;
        public string DateText
        {
            get => _dateText;
            set
            {
                _dateText = value;
                OnPropertyChanged(nameof(DateText));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand ReturnCommand { get; }

        public WorkOrdersConfirmViewModel(IServiceProvider services)
        {
            _maintenances = new ObservableCollection<Models.Maintenance>(services.GetRequiredService<SelectedWorkOrder>().WorkOrder.Maintenances);
            Persons = services.GetRequiredService<PersonProvider>().GetAll().Result;

            ReturnCommand = new NavigateCommand<WorkOrdersListViewModel>(services.GetRequiredService<NavigationService<WorkOrdersListViewModel>>());
            SaveCommand = new WorkOrderSaveCommand(services, this);
        }
    }
}