namespace PrzegladyRemonty.Models
{
    public class Maintenance
    {
        private Person _mechanic;
        private TransporterAction _action;

        public int Id { get; }
        public string MaintenanceDate { get; }
        public int MechanicId { get; set; }
        public Person Mechanic => _mechanic;
        public int MaintenanceActionId { get; }
        public TransporterAction Action => _action;
        public bool Completed
        { get; }
        public string Description { get; set; }

        public Maintenance(
            int maintenanceAction)
        {
            MaintenanceActionId = maintenanceAction;
        }

        public Maintenance(
            int id,
            string maintenanceDate,
            int mechanic,
            int maintenanceAction,
            bool completed,
            string description)
        {
            Id = id;
            MaintenanceDate = maintenanceDate;
            MechanicId = mechanic;
            MaintenanceActionId = maintenanceAction;
            Completed = completed;
            Description = description;
        }

        public void SetMechanic(Person mechanic)
        {
            _mechanic = mechanic;
        }

        public void SetAction(TransporterAction action)
        {
            _action = action;
        }
    }
}
