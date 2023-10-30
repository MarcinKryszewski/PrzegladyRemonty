﻿namespace PrzegladyRemonty.Models
{
    public class Maintenance
    {
        public int Id { get; }
        public string MaintenanceDate { get; }
        public int Mechanic { get; }
        public int MaintenanceAction { get; }
        public bool Completed { get; }
        public string Description { get; }

        public Maintenance(
            string maintenanceDate,
            int mechanic,
            int maintenanceAction,
            string description)
        {
            MaintenanceDate = maintenanceDate;
            Mechanic = mechanic;
            MaintenanceAction = maintenanceAction;
            Description = description;
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
            Mechanic = mechanic;
            MaintenanceAction = maintenanceAction;
            Completed = completed;
            Description = description;
        }


    }
}