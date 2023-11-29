using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Login
{
    public class FillDatabaseCommand : AsyncCommandBase
    {
        private IServiceProvider _databaseServices;
        private LoginViewModel _viewModel;

        public FillDatabaseCommand(IServiceProvider databaseServices, LoginViewModel viewModel)
        {
            _databaseServices = databaseServices;
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            AddLines();
            AddAreas();
            AddParts();
            AddTransporterTypes();
            AddTransporters();
            AddTransporterParts();
            AddPermissions();
            AddPerson();
            AddPersonPermission();
            AddActionCategorys();
            AddTransporterActions();
            AddWorkOrders();
            AddMaintenances();
            AddWorkOrderMaintenances();

            _viewModel.DatabaseEmpty = false;

            return Task.CompletedTask;
        }

        private void AddLines()
        {
            LineProvider provider = _databaseServices.GetRequiredService<LineProvider>();

            provider.Create(new Line("RB1"));
            provider.Create(new Line("RB2"));
            provider.Create(new Line("Linia puszkowa"));
        }
        private void AddAreas()
        {
            AreaProvider provider = _databaseServices.GetRequiredService<AreaProvider>();

            provider.Create(new Area("Od depaletyzatora do inspektora bbull", 1));
            provider.Create(new Area("Od rozdzielacza paletyzatora", 1));
            provider.Create(new Area("Transport wolny wyładowarki", 1));

            provider.Create(new Area("Transport szybki wyładowarki", 2));
            provider.Create(new Area("Transport kruszarki", 2));
            provider.Create(new Area("Transport powrotny z monobloku przed buforem myjki", 2));

            provider.Create(new Area("Transportery puszek pełnych", 3));
            provider.Create(new Area("Transportery puszek pustych", 3));
            provider.Create(new Area("Transportery tacek", 3));
        }
        private void AddParts()
        {
            PartProvider provider = _databaseServices.GetRequiredService<PartProvider>();

            provider.Create(new Part("Koło bierne", "Krones", "d=30 L=55"));
            provider.Create(new Part("Koło bierne", "Krones", "d=30 L=75"));
            provider.Create(new Part("Koło łańcuchowe", "Krones", "d=30 Z=14"));
            provider.Create(new Part("Koło łańcuchowe", "Krones", "d=40 Z=14"));
            provider.Create(new Part("Koło napędowe", "Krones", "d=30 Z=19"));
            provider.Create(new Part("Koło napędowe", "Krones", "d=30 Z=21"));
            provider.Create(new Part("Łańcuch płytkowy", "Krones", "60S31S"));
            provider.Create(new Part("Łańcuch płytkowy", "Krones", "661S84SM"));
            provider.Create(new Part("Łożysko", "Krones", "GRAE NPPB-208;AH01 FA140"));
        }
        private void AddTransporterTypes()
        {
            TransporterTypeProvider provider = _databaseServices.GetRequiredService<TransporterTypeProvider>();

            provider.Create(new TransporterType("Transporter butelek"));
            provider.Create(new TransporterType("Transporter skrzynek"));
            provider.Create(new TransporterType("Transporter palet"));
            provider.Create(new TransporterType("Transporter puszek"));
        }
        private void AddTransporters()
        {
            TransporterProvider provider = _databaseServices.GetRequiredService<TransporterProvider>();

            provider.Create(new Transporter("TBB1.1453", 1, 1));
            provider.Create(new Transporter("TBG1.9848", 2, 2));
            provider.Create(new Transporter("TBP1.3232", 3, 3));
            provider.Create(new Transporter("TBB2.5641", 4, 1));
            provider.Create(new Transporter("TBG2.1324", 5, 2));
            provider.Create(new Transporter("TBP2.1542", 6, 3));
            provider.Create(new Transporter("WAM63", 7, 3));
            provider.Create(new Transporter("ESM21", 8, 4));
            provider.Create(new Transporter("ESM14", 9, 4));
        }
        private void AddTransporterParts()
        {
            TransporterPartProvider provider = _databaseServices.GetRequiredService<TransporterPartProvider>();

            provider.Create(new TransporterPart(1, 5, 1, "szt"));
            provider.Create(new TransporterPart(1, 4, 2, "szt"));
            provider.Create(new TransporterPart(2, 6, 5, "szt"));
            provider.Create(new TransporterPart(2, 7, 6, "szt"));
            provider.Create(new TransporterPart(3, 8, 1, "szt"));
            provider.Create(new TransporterPart(4, 1, 2, "szt"));
            provider.Create(new TransporterPart(5, 2, 2, "szt"));
            provider.Create(new TransporterPart(6, 9, 1, "szt"));
            provider.Create(new TransporterPart(7, 3, 1, "szt"));
            provider.Create(new TransporterPart(8, 5, 20, "szt"));
            provider.Create(new TransporterPart(9, 4, 10, "szt"));
            provider.Create(new TransporterPart(4, 1, 5, "szt"));
            provider.Create(new TransporterPart(2, 1, 4, "szt"));

        }
        private void AddPermissions()
        {
            PermissionProvider provider = _databaseServices.GetRequiredService<PermissionProvider>();

            provider.Create(new Permission("ADMIN", 7545));
            provider.Create(new Permission("MANAGER", 2342));
            provider.Create(new Permission("MECHANIC", 3434));
        }
        private void AddPerson()
        {
            PersonProvider provider = _databaseServices.GetRequiredService<PersonProvider>();

            provider.Create(new Person("ADMIN", "ADMIN", "ADMIN"));
            provider.Create(new Person("grzebyc01", "Celestyna", "Grzebyta"));
            provider.Create(new Person("kowalj01", "Jan", "Kowalski"));
            provider.Create(new Person("nowaka02", "Adam", "Nowak"));
            provider.Create(new Person("kryszm02", "Marcin", "Kryszewski"));
        }
        private void AddPersonPermission()
        {
            PersonPermissionProvider provider = _databaseServices.GetRequiredService<PersonPermissionProvider>();

            provider.Create(new PersonPermission(1, 1));
            provider.Create(new PersonPermission(2, 2));
            provider.Create(new PersonPermission(3, 3));
            provider.Create(new PersonPermission(4, 3));
        }
        private void AddActionCategorys()
        {
            ActionCategoryProvider provider = _databaseServices.GetRequiredService<ActionCategoryProvider>();

            provider.Create(new ActionCategory("Kontrola luzów i uszkodzeń łożysk"));
            provider.Create(new ActionCategory("Kontrola łańcuchów płytkowych"));
            provider.Create(new ActionCategory("Kontrola rolek"));
            provider.Create(new ActionCategory("Wymiana oleju reduktora napędu"));
            provider.Create(new ActionCategory("Smarowanie łożysk"));
        }
        private void AddTransporterActions()
        {
            TransporterActionProvider provider = _databaseServices.GetRequiredService<TransporterActionProvider>();

            provider.Create(new TransporterAction(1, 1, 3, "M"));
            provider.Create(new TransporterAction(1, 3, 3, "M"));
            provider.Create(new TransporterAction(2, 2, 3, "M"));
            provider.Create(new TransporterAction(2, 4, 3, "M"));
            provider.Create(new TransporterAction(3, 5, 3, "M"));
            provider.Create(new TransporterAction(3, 1, 3, "M"));
            provider.Create(new TransporterAction(4, 2, 3, "M"));
            provider.Create(new TransporterAction(4, 4, 3, "M"));
            provider.Create(new TransporterAction(5, 5, 3, "M"));
            provider.Create(new TransporterAction(5, 1, 3, "M"));
            provider.Create(new TransporterAction(6, 2, 3, "M"));
            provider.Create(new TransporterAction(6, 3, 3, "M"));
            provider.Create(new TransporterAction(7, 4, 3, "M"));
            provider.Create(new TransporterAction(7, 1, 3, "M"));
            provider.Create(new TransporterAction(8, 2, 3, "M"));
            provider.Create(new TransporterAction(8, 5, 3, "M"));
            provider.Create(new TransporterAction(9, 3, 3, "M"));
            provider.Create(new TransporterAction(9, 5, 3, "M"));
        }
        private void AddWorkOrders()
        {
            WorkOrderProvider provider = _databaseServices.GetRequiredService<WorkOrderProvider>();

            provider.Create(new WorkOrder("2023-11-20", 3));
            provider.Create(new WorkOrder("2023-10-14", 3));
            provider.Create(new WorkOrder("2023-09-30", 4));
            provider.Create(new WorkOrder("2023-09-04", 3));
            provider.Create(new WorkOrder("2023-11-10", 3));
            provider.Create(new WorkOrder("2023-10-26", 4));
            provider.Create(new WorkOrder("2023-09-20", 3));
        }
        private void AddMaintenances()
        {
            MaintenanceProvider provider = _databaseServices.GetRequiredService<MaintenanceProvider>();

            provider.Create(new Models.Maintenance(1));
            provider.Create(new Models.Maintenance(4));
            provider.Create(new Models.Maintenance(11));
            provider.Create(new Models.Maintenance(12));
            provider.Create(new Models.Maintenance(7));
            provider.Create(new Models.Maintenance(8));

            provider.Update(new Models.Maintenance(1, "2023-11-24", 3, 1, false, "Wszystko OK"));
            provider.Update(new Models.Maintenance(2, "2023-11-24", 3, 4, false, "W normie"));
            provider.Update(new Models.Maintenance(3, "2023-11-24", 4, 11, false, "Sprawdzone"));
            provider.Update(new Models.Maintenance(4, "2023-11-24", 4, 12, false, "Stan dobry"));
            provider.Update(new Models.Maintenance(5, "2023-11-24", 3, 7, false, "Kontrola wykonana"));
            provider.Update(new Models.Maintenance(6, "2023-11-24", 3, 8, false, "Wymiana"));
        }
        private void AddWorkOrderMaintenances()
        {
            WorkOrderMaintenanceProvider provider = _databaseServices.GetRequiredService<WorkOrderMaintenanceProvider>();

            provider.Create(new WorkOrderMaintenance(1, 1));
            provider.Create(new WorkOrderMaintenance(2, 2));
            provider.Create(new WorkOrderMaintenance(3, 3));
            provider.Create(new WorkOrderMaintenance(4, 4));
            provider.Create(new WorkOrderMaintenance(5, 5));
            provider.Create(new WorkOrderMaintenance(6, 6));
        }
    }
}