using System.Collections.Generic;

namespace PrzegladyRemonty.Database.MS_Access
{
    public class MsAccessInitCommands
    {
        public List<string> InitCommands { get; }

        private const string _lineSQLCommand = @"
            CREATE TABLE line (
                Id AUTOINCREMENT PRIMARY KEY, 
                Name VARCHAR, 
                Active BIT
            );";
        private const string _areaSQLCommand = @"
            CREATE TABLE area (
                Id AUTOINCREMENT PRIMARY KEY, 
                Name VARCHAR, 
                Active BIT, 
                Line INT, 
                FOREIGN KEY (Line) REFERENCES line (Id)
            );";
        private const string _transporterSQLCommand = @"
            CREATE TABLE transporter (
                Id AUTOINCREMENT PRIMARY KEY, 
                Name VARCHAR, 
                Active BIT, 
                Area INT, 
                LastMaintenance DATETIME, 
                FOREIGN KEY (Area) REFERENCES area (Id)
            );";
        private const string _actionCategorySQLCommand = @"
            CREATE TABLE actionCategory (
                Id AUTOINCREMENT PRIMARY KEY, 
                Name VARCHAR
            );";
        private const string _transporterActionSQLCommand = @"
            CREATE TABLE transporterAction (
                Id AUTOINCREMENT PRIMARY KEY, 
                Transporter INT, 
                MaintenanceAction INT, 
                Frequency INT, 
                FrequencyUnit VARCHAR, 
                FOREIGN KEY (Transporter) REFERENCES transporter (Id), 
                FOREIGN KEY (MaintenanceAction) REFERENCES actionCategory (Id)
            );";
        private const string _permissionSQLCommand = @"
            CREATE TABLE permission (
                Id AUTOINCREMENT PRIMARY KEY, 
                Name VARCHAR, 
                PermissionValue INT
            );";
        private const string _personSQLCommand = @"
            CREATE TABLE person (
                Id AUTOINCREMENT PRIMARY KEY, 
                Login VARCHAR, 
                Name VARCHAR, 
                Surname VARCHAR, 
                Active BIT
            );";
        private const string _personPermissionSQLCommand = @"
            CREATE TABLE personPermission (
                Id AUTOINCREMENT PRIMARY KEY, 
                Person INT, 
                Permission INT, 
                FOREIGN KEY (Person) REFERENCES person (Id), 
                FOREIGN KEY (Permission) REFERENCES permission (Id)
            );";
        private const string _maintenanceSQLCommand = @"
            CREATE TABLE maintenance (
                Id AUTOINCREMENT PRIMARY KEY, 
                MaintenanceDate DATETIME, 
                Mechanic INT, 
                MaintenanceAction INT, 
                Completed BIT, 
                Description VARCHAR,
                FOREIGN KEY (Mechanic) REFERENCES person (Id), 
                FOREIGN KEY (MaintenanceAction) REFERENCES transporterAction (Id)
            );";
        private const string _workOrderSQLCommand = @"
            CREATE TABLE workOrder (
                Id AUTOINCREMENT PRIMARY KEY, 
                Created DATETIME, 
                CreatedBy INT, 
                FOREIGN KEY (CreatedBy) REFERENCES person (Id)
            );";
        private const string _workOrderMaintenanceSQLCommand = @"
            CREATE TABLE workOrderMaintenance (
                Id AUTOINCREMENT PRIMARY KEY, 
                WorkOrder INT, 
                Maintenance INT, 
                FOREIGN KEY (WorkOrder) 
                REFERENCES workOrder (Id), 
                FOREIGN KEY (Maintenance) REFERENCES maintenance (Id)
            );";

        public MsAccessInitCommands()
        {
            InitCommands = new List<string>
            {
                _lineSQLCommand,
                _areaSQLCommand,
                _transporterSQLCommand,
                _actionCategorySQLCommand,
                _transporterActionSQLCommand,
                _permissionSQLCommand,
                _personSQLCommand,
                _personPermissionSQLCommand,
                _maintenanceSQLCommand,
                _workOrderSQLCommand,
                _workOrderMaintenanceSQLCommand
            };
        }

    }
}
