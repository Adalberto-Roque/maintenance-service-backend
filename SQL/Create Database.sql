CREATE DATABASE Example

CREATE SCHEMA Vehicles
CREATE SCHEMA Employees
CREATE SCHEMA MaintenanceServices

USE Example

CREATE TABLE Vehicles.Trucks(
	IdTruck smallint NOT NULL Identity(1,1),
	Number varchar(5) NOT NULL,
	LicensePlate varchar(8),	

	CONSTRAINT PK_Trucks_IdVehicle PRIMARY KEY(IdTruck)
)

CREATE TABLE Employees.Jobs(
	IdJob smallint NOT NULL  Identity(1,1),
	JobDescription varchar(30) NOT NULL,

	CONSTRAINT PK_Jobs_IdJob PRIMARY KEY(IdJob)
)

CREATE TABLE Employees.Employees(
	IdEmployee smallint NOT NULL  Identity(1,1),
	IdJob smallint NOT NULL,
	FirstName varchar(15),
	LastName varchar(15),
	EmployeeNumber varchar(10),
	IdTruck smallint

	CONSTRAINT PK_Employees_IdEmployee PRIMARY KEY(IdEmployee),
	CONSTRAINT FK_Employees_Jobs_IdJob FOREIGN KEY(IdJob) REFERENCES Employees.Jobs(IdJob),
	CONSTRAINT FK_Employees_Trucks_IdTruck FOREIGN KEY(IdTruck) REFERENCES  Vehicles.Trucks(IdTruck)
)

--CREATE TABLE Employees.EmployeesJobs(
--	IdEmployeeJob smallint NOT NULL  Identity(1,1),
--	IdEmployee smallint NOT NULL,
--	IdJob smallint NOT NULL

--	CONSTRAINT PK_EmployeesJobs_IdEmployeeJob PRIMARY KEY(IdEmployeeJob),
--	CONSTRAINT FK_EmployeesJobs_Employees_IdEmployee FOREIGN KEY (IdEmployee) REFERENCES Employees.Employees(IdEmployee),
--	CONSTRAINT FK_EmployeesJobs_Jobs_IdJob FOREIGN KEY (IdJob) REFERENCES Employees.Jobs(IdJob),
--)

CREATE TABLE MaintenanceServices.TypeTruckMaintenanceServices(
	IdTypeTruckMaintenanceService tinyint NOT NULL  Identity(1,1),
	TypeDescription varchar(30) NOT NULL

	CONSTRAINT PK_TypeTruckMaintenanceServices_IdTypeTruckMaintenanceService PRIMARY KEY(IdTypeTruckMaintenanceService)
)

CREATE TABLE MaintenanceServices.TruckMaintenanceServices(
	IdTruckMaintenanceServices int NOT NULL  Identity(1,1),
	IdTruck smallint NOT NULL,
	IdTypeTruckMaintenanceService tinyint NOT NULL,
	Driver smallint NOT NULL,
	Dispatcher smallint NOT NULL,
	DueDate datetime NOT NULL,
	Mechanical smallint NOT NULL,

	CONSTRAINT PK_TruckMaintenanceServices_IdTruckMaintenanceServices PRIMARY KEY(IdTruckMaintenanceServices),
	CONSTRAINT FK_TruckMaintenanceServices_Vehicles_IdTruck FOREIGN KEY(IdTruck) REFERENCES Vehicles.Trucks(IdTruck),
	CONSTRAINT FK_TruckMaintenanceServices_Vehicles_IdTypeTruckMaintenanceService FOREIGN KEY(IdTypeTruckMaintenanceService) REFERENCES MaintenanceServices.TypeTruckMaintenanceServices(IdTypeTruckMaintenanceService),
	CONSTRAINT FK_TruckMaintenanceServices_Employees_Driver FOREIGN KEY(Driver) REFERENCES Employees.Employees(IdEmployee),
	CONSTRAINT FK_TruckMaintenanceServices_Employees_Dispatcher FOREIGN KEY(Dispatcher) REFERENCES Employees.Employees(IdEmployee),
	CONSTRAINT FK_TruckMaintenanceServices_Employees_Mechanical FOREIGN KEY(Mechanical) REFERENCES Employees.Employees(IdEmployee),
)

INSERT INTO Vehicles.Trucks(Number, LicensePlate)
VALUES('80', 'ABC-0000'),('81', 'ABC-0001'),('82', 'ABC-0002'),('83', 'ABC-0003'),('84', 'ABC-0004'),('85', 'ABC-0005')

INSERT INTO Employees.Jobs(JobDescription) 
VALUES('Driver'),('Dispatcher'),('Mechanical')

INSERT INTO Employees.Employees(IdJob,FirstName,LastName,EmployeeNumber,IdTruck) 
VALUES(1,'Pedro', 'Jimenez', '0000', 1),(1,'Raúl', 'Jimenez', '0001', 2),(1,'Sebastian', 'Lopez', '0002', 3),
(2,'Javier', 'Estrada', '0003', null),(2,'Esteban', 'Garcia', '0004', null),
(3,'Andres', 'Robles', '0005', null)

INSERT INTO MaintenanceServices.TypeTruckMaintenanceServices(TypeDescription)
VALUES('Type 1'), ('Type 2'), ('Type 3')