using System.Collections.ObjectModel;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersActionsAddCommand : CommandBase
    {
        private ObservableCollection<ActionCategory> _actionsSelected;
        private ObservableCollection<ActionCategory> _actionsList;

        public TransportersActionsAddCommand(ObservableCollection<ActionCategory> actionsSelected, ObservableCollection<ActionCategory> actionsList)
        {
            _actionsSelected = actionsSelected;
            _actionsList = actionsList;
        }

        public override void Execute(object parameter)
        {
            foreach (ActionCategory action in _actionsSelected)
            {
                if (!_actionsList.Contains(action)) _actionsList.Add(action);
            }
        }
    }
}