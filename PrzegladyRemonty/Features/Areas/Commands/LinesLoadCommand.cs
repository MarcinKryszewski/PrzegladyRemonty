using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PrzegladyRemonty.Features.Areas
{
    public class LinesLoadCommand : AsyncCommandBase
    {
        private readonly LineProvider _provider;
        private readonly AreasViewModel _viewModel;

        public LinesLoadCommand(AreasViewModel viewModel, LineProvider lineProvider)
        {
            _provider = lineProvider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Line> lines = await _provider.GetAll();
                _viewModel.UpdateLines(lines);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load lines.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
