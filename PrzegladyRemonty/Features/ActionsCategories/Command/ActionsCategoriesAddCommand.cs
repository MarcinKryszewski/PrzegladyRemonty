using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesAddCommand : CommandBase
    {
        readonly ActionCategoryProvider _provider;
        readonly ActionsCategoriesAddViewModel _viewModel;
        public ActionsCategoriesAddCommand(ActionsCategoriesAddViewModel viewModel, ActionCategoryProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            string name = _viewModel.Name;

            ActionCategory part = new(name);
            part.Add(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}