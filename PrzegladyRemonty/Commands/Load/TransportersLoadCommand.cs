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
    public class TransportersLoadCommand : AsyncCommandBase
    {
        private readonly TransporterProvider _provider;
        private readonly ITransporterUpdate _viewModel;

        public TransportersLoadCommand(ITransporterUpdate viewModel, TransporterProvider transporterProvider)
        {
            _provider = transporterProvider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Transporter> transporters = await _provider.GetAll();
                _viewModel.UpdateTransporters(transporters);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load transporters.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
