using System.Collections.ObjectModel;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersPartsAddCommand : CommandBase
    {
        private ObservableCollection<Part> _partsSelected;
        private ObservableCollection<Part> _partsList;

        public TransportersPartsAddCommand(ObservableCollection<Part> partsSelected, ObservableCollection<Part> partsList)
        {
            _partsSelected = partsSelected;
            _partsList = partsList;
        }

        public override void Execute(object parameter)
        {
            foreach (Part part in _partsSelected)
            {
                //if (!_partsList.Contains(part)) _partsList.Add(part);
            }
        }
    }
}