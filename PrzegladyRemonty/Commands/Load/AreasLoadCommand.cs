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
    public class AreasLoadCommand : AsyncCommandBase
    {
        private readonly AreaProvider _provider;
        private readonly IAreaUpdate _viewModel;

        public AreasLoadCommand(IAreaUpdate viewModel, AreaProvider areaProvider)
        {
            _provider = areaProvider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Area> areas = await _provider.GetAll();
                _viewModel.UpdateAreas(areas);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load areas.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}