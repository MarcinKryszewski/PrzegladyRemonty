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
    public class PartsLoadCommand : AsyncCommandBase
    {
        private readonly PartProvider _provider;
        private readonly IPartUpdate _viewModel;

        public PartsLoadCommand(IPartUpdate viewModel, PartProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Part> parts = await _provider.GetAll();
                _viewModel.UpdateParts(parts);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load parts.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}