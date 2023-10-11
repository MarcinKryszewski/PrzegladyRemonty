BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "areas" (
	"id"	INTEGER,
	"name"	TEXT,
	"active"	INTEGER,
	"line"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("line") REFERENCES "lines"
);
CREATE TABLE IF NOT EXISTS "lines" (
	"id"	INTEGER,
	"name"	TEXT,
	"active"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "transporters" (
	"id"	INTEGER,
	"area"	INTEGER,
	"name"	TEXT,
	"active"	INTEGER,
	"lastMaintenance"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("area") REFERENCES "areas"("id")
);
CREATE TABLE IF NOT EXISTS "actionsCategories" (
	"id"	INTEGER,
	"name"	TEXT,
	"frequency"	INTEGER,
	"frequencyUnit"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "transporters_actions" (
	"id"	INTEGER,
	"transporter"	INTEGER,
	"action"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("action") REFERENCES "actionsCategories"("id"),
	FOREIGN KEY("transporter") REFERENCES "transporters"("id")
);
CREATE TABLE IF NOT EXISTS "permissions" (
	"id"	INTEGER,
	"value"	INTEGER,
	"name"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "users" (
	"id"	INTEGER,
	"login"	TEXT,
	"name"	TEXT,
	"surname"	TEXT,
	"active"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "users_permissions" (
	"id"	INTEGER,
	"user"	INTEGER,
	"permission"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("user") REFERENCES "users"("id"),
	FOREIGN KEY("permission") REFERENCES "users_permissions"("id")
);
CREATE TABLE IF NOT EXISTS "maintenances" (
	"id"	INTEGER,
	"maintenanceDate"	TEXT,
	"mechanic"	INTEGER,
	"action"	INTEGER,
	"completed"	INTEGER,
	"comment"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("action") REFERENCES "transporters_actions"("id"),
	FOREIGN KEY("mechanic") REFERENCES "users"("id")
);
CREATE TABLE IF NOT EXISTS "workOrders_maintenances" (
	"id"	INTEGER,
	"workOrder"	INTEGER,
	"maintenance"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("workOrder") REFERENCES "workOrders"("id"),
	FOREIGN KEY("maintenance") REFERENCES "maintenances"("id")
);
CREATE TABLE IF NOT EXISTS "workOrders" (
	"id"	INTEGER,
	"createdDate"	TEXT,
	"createdBy"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("createdBy") REFERENCES "users"("id")
);
COMMIT;
