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
    public class ActionsCategoriesLoadCommand : AsyncCommandBase
    {
        private readonly ActionCategoryProvider _provider;
        private readonly IActionCategoryUpdate _viewModel;

        public ActionsCategoriesLoadCommand(IActionCategoryUpdate viewModel, ActionCategoryProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<ActionCategory> actions = await _provider.GetAll();
                _viewModel.UpdateActions(actions);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load areas.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}