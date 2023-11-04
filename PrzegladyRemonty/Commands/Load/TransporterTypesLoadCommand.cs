using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PrzegladyRemonty.Commands.Load
{
    public class TransporterTypesLoadCommand : AsyncCommandBase
    {
        private readonly TransporterTypeProvider _provider;
        private readonly ITransporterTypeUpdate _viewModel;

        public TransporterTypesLoadCommand(ITransporterTypeUpdate viewModel, TransporterTypeProvider areaProvider)
        {
            _provider = areaProvider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<TransporterType> transporterTypes = await _provider.GetAll();
                _viewModel.UpdateTransporterTypes(transporterTypes);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load areas.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
