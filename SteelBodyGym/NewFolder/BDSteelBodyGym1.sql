CREATE DATABASE SteelBodyGym;

USE SteelBodyGym;

-- Rol Table: User roles in the gym 
CREATE TABLE Roles (
    Id_Rol UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Rol_Name VARCHAR(50) NOT NULL
);

CREATE TABLE ViewsPerRoles (
    Id_ViewsPerRoles UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Id_Rol UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (Id_Rol) REFERENCES Roles(Id_Rol),
);
-- Users Table: Basic user information

CREATE TABLE IdentificationTypes(
Identification_Type_ID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
Name VARCHAR(50)
)

-- UserState Table: Possible states of a user (active, inactive, etc.)
CREATE TABLE UserState (
    Id_State UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    State_Name VARCHAR(50) NOT NULL
);

CREATE TABLE Users (
    Id_User UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
	Id_Number VARCHAR(50) NOT NULL ,
    Name VARCHAR(50) NOT NULL,
    Firstname VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
    Birth_Date DATE NOT NULL,
    Gender VARCHAR(10),
    Id_Rol UNIQUEIDENTIFIER NOT NULL,
	Identification_Type_ID UNIQUEIDENTIFIER NOT NULL ,
	Id_State UNIQUEIDENTIFIER NOT NULL
    FOREIGN KEY (Id_Rol) REFERENCES Roles(Id_Rol),
	FOREIGN KEY (Identification_Type_ID) REFERENCES IdentificationTypes(Identification_Type_ID),
	FOREIGN KEY (Id_State) REFERENCES UserState(Id_State)
);



-- GymRoutines Table: Information about the routines available in the gym
CREATE TABLE GymRoutines (
    Id_Routine UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Routine_Name VARCHAR(50) NOT NULL
);

CREATE TABLE GymMachines (
    Id_Machine UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Machine_Name VARCHAR(50) NOT NULL
);

-- RoutinesPerUser Table: Relationship between users and routines
CREATE TABLE RoutinesPerUser (
	Routines_Per_Person_ID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Id_User UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    Id_Routine UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	Weight INT,
	Quantity INT,
	Id_Machine UNIQUEIDENTIFIER,
	Time DATETIME,
    FOREIGN KEY (Id_User) REFERENCES Users(Id_User),
    FOREIGN KEY (Id_Routine) REFERENCES GymRoutines(Id_Routine),
	FOREIGN KEY (Id_Machine) REFERENCES GymMachines(Id_Machine)

);


--  Province Table, Canton, District : Geographic information
CREATE TABLE Province (
    Id_Province UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Province_Name VARCHAR(50) NOT NULL
);

CREATE TABLE Counties (
    Id_Counties UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Name VARCHAR(50) NOT NULL,
    Id_Province UNIQUEIDENTIFIER,
    FOREIGN KEY (Id_Province) REFERENCES Province(Id_Province)
);

CREATE TABLE Cities (
    Id_Cities UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Name VARCHAR(50) NOT NULL,
    Id_Counties UNIQUEIDENTIFIER,
    FOREIGN KEY (Id_Cities) REFERENCES Counties(Id_Counties)
);

-- PaymentType Table: Types of payments (card, cash, etc.)
CREATE TABLE PaymentTypes (
    Id_Payment_Type UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Name VARCHAR(50) NOT NULL
);

-- RegistrationTypes Table: Types of gym membership (monthly, annual, etc.)
CREATE TABLE MembershipRegistrationTypes (
    Id_Membership_Registration_Types UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Registration_Type_Name VARCHAR(50) NOT NULL
);

-- PaymentsPerUser Table: Information about payments made by each user
CREATE TABLE PaymentsPerUser (
    Id_Payments_Per_User UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Id_User UNIQUEIDENTIFIER,
    Payment_Day DATE NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    Id_Payment_Type UNIQUEIDENTIFIER,
    Id_Membership_Registration_Types UNIQUEIDENTIFIER,
    FOREIGN KEY (Id_User) REFERENCES Users(Id_User),
    FOREIGN KEY (Id_Payment_Type) REFERENCES PaymentTypes(Id_Payment_Type),
    FOREIGN KEY (Id_Membership_Registration_Types) REFERENCES MembershipRegistrationTypes(Id_Membership_Registration_Types)
);

-- Body MeasurementsUser Table: Information about users' body measurements
CREATE TABLE BodyMeasurementsUser (
    Id_Measure UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT(NEWID()),
    Id_User UNIQUEIDENTIFIER,
    Measurement_Date DATE NOT NULL,
    Height DECIMAL(5, 2),
    Weight DECIMAL(5, 2),
    Waist DECIMAL(5, 2),
    FOREIGN KEY (Id_User) REFERENCES Users(Id_User)
);
