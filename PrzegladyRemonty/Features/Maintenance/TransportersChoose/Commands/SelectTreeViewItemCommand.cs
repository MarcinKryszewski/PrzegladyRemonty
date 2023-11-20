using PrzegladyRemonty.Models;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class SelectTreeViewItemCommand : CommandBase
    {
        private readonly TransporterStore _selectedTransporter;
        private readonly MaintenanceTransporterStore _selectedGlobalTransporter;

        public SelectTreeViewItemCommand(TransporterStore selectedTransporter, MaintenanceTransporterStore selectedGlobalTransporter)
        {
            _selectedTransporter = selectedTransporter;
            _selectedGlobalTransporter = selectedGlobalTransporter;
        }

        public override void Execute(object parameter)
        {
            if (parameter is not Transporter) return;
            _selectedTransporter.Transporter = (Transporter)parameter;
            _selectedGlobalTransporter.Transporter = (Transporter)parameter;
        }
    }
}
