USE [master]
GO
/****** Object:  Database [SteelBodyGym]    Script Date: 2/23/2024 5:49:01 PM ******/
CREATE DATABASE [SteelBodyGym]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SteelBodyGym', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SteelBodyGym.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SteelBodyGym_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SteelBodyGym_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SteelBodyGym] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SteelBodyGym].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SteelBodyGym] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SteelBodyGym] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SteelBodyGym] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SteelBodyGym] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SteelBodyGym] SET ARITHABORT OFF 
GO
ALTER DATABASE [SteelBodyGym] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SteelBodyGym] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SteelBodyGym] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SteelBodyGym] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SteelBodyGym] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SteelBodyGym] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SteelBodyGym] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SteelBodyGym] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SteelBodyGym] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SteelBodyGym] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SteelBodyGym] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SteelBodyGym] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SteelBodyGym] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SteelBodyGym] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SteelBodyGym] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SteelBodyGym] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SteelBodyGym] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SteelBodyGym] SET RECOVERY FULL 
GO
ALTER DATABASE [SteelBodyGym] SET  MULTI_USER 
GO
ALTER DATABASE [SteelBodyGym] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SteelBodyGym] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SteelBodyGym] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SteelBodyGym] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SteelBodyGym] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SteelBodyGym] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SteelBodyGym', N'ON'
GO
ALTER DATABASE [SteelBodyGym] SET QUERY_STORE = ON
GO
ALTER DATABASE [SteelBodyGym] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SteelBodyGym]
GO
/****** Object:  Table [dbo].[BodyMeasurementsUser]    Script Date: 2/23/2024 5:49:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyMeasurementsUser](
	[Id_Measure] [uniqueidentifier] NOT NULL,
	[Id_User] [uniqueidentifier] NULL,
	[Measurement_Date] [date] NOT NULL,
	[Height] [decimal](5, 2) NULL,
	[Weight] [decimal](5, 2) NULL,
	[Waist] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Measure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id_Cities] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Id_Counties] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cities] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counties]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counties](
	[Id_Counties] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Id_Province] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Counties] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GymMachines]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GymMachines](
	[Id_Machine] [uniqueidentifier] NOT NULL,
	[Machine_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Machine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GymRoutines]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GymRoutines](
	[Id_Routine] [uniqueidentifier] NOT NULL,
	[Routine_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Routine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentificationTypes]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentificationTypes](
	[Identification_Type_ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Identification_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipRegistrationTypes]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipRegistrationTypes](
	[Id_Membership_Registration_Types] [uniqueidentifier] NOT NULL,
	[Registration_Type_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Membership_Registration_Types] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentsPerUser]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentsPerUser](
	[Id_Payments_Per_User] [uniqueidentifier] NOT NULL,
	[Id_User] [uniqueidentifier] NULL,
	[Payment_Day] [date] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Id_Payment_Type] [uniqueidentifier] NULL,
	[Id_Membership_Registration_Types] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Payments_Per_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTypes]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTypes](
	[Id_Payment_Type] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Payment_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Id_Province] [uniqueidentifier] NOT NULL,
	[Province_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Province] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_Rol] [uniqueidentifier] NOT NULL,
	[Rol_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoutinesPerUser]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutinesPerUser](
	[Routines_Per_Person_ID] [uniqueidentifier] NOT NULL,
	[Id_User] [uniqueidentifier] NOT NULL,
	[Id_Routine] [uniqueidentifier] NOT NULL,
	[Weight] [int] NULL,
	[Quantity] [int] NULL,
	[Id_Machine] [uniqueidentifier] NULL,
	[Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Routines_Per_Person_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_User] [uniqueidentifier] NOT NULL,
	[Id_Number] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Birth_Date] [date] NOT NULL,
	[Gender] [varchar](10) NULL,
	[Id_Rol] [uniqueidentifier] NOT NULL,
	[Identification_Type_ID] [uniqueidentifier] NOT NULL,
	[Id_State] [uniqueidentifier] NOT NULL,
	[Id_Province] [uniqueidentifier] NULL,
	[Id_Counties] [uniqueidentifier] NULL,
	[Id_Cities] [uniqueidentifier] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserState]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserState](
	[Id_State] [uniqueidentifier] NOT NULL,
	[State_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewsPerRoles]    Script Date: 2/23/2024 5:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewsPerRoles](
	[Id_ViewsPerRoles] [uniqueidentifier] NOT NULL,
	[Id_Rol] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_ViewsPerRoles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BodyMeasurementsUser] ADD  DEFAULT (newid()) FOR [Id_Measure]
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT (newid()) FOR [Id_Cities]
GO
ALTER TABLE [dbo].[Counties] ADD  DEFAULT (newid()) FOR [Id_Counties]
GO
ALTER TABLE [dbo].[GymMachines] ADD  DEFAULT (newid()) FOR [Id_Machine]
GO
ALTER TABLE [dbo].[GymRoutines] ADD  DEFAULT (newid()) FOR [Id_Routine]
GO
ALTER TABLE [dbo].[IdentificationTypes] ADD  DEFAULT (newid()) FOR [Identification_Type_ID]
GO
ALTER TABLE [dbo].[MembershipRegistrationTypes] ADD  DEFAULT (newid()) FOR [Id_Membership_Registration_Types]
GO
ALTER TABLE [dbo].[PaymentsPerUser] ADD  DEFAULT (newid()) FOR [Id_Payments_Per_User]
GO
ALTER TABLE [dbo].[PaymentTypes] ADD  DEFAULT (newid()) FOR [Id_Payment_Type]
GO
ALTER TABLE [dbo].[Province] ADD  DEFAULT (newid()) FOR [Id_Province]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (newid()) FOR [Id_Rol]
GO
ALTER TABLE [dbo].[RoutinesPerUser] ADD  DEFAULT (newid()) FOR [Routines_Per_Person_ID]
GO
ALTER TABLE [dbo].[RoutinesPerUser] ADD  DEFAULT (newid()) FOR [Id_User]
GO
ALTER TABLE [dbo].[RoutinesPerUser] ADD  DEFAULT (newid()) FOR [Id_Routine]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [Id_User]
GO
ALTER TABLE [dbo].[UserState] ADD  DEFAULT (newid()) FOR [Id_State]
GO
ALTER TABLE [dbo].[ViewsPerRoles] ADD  DEFAULT (newid()) FOR [Id_ViewsPerRoles]
GO
ALTER TABLE [dbo].[BodyMeasurementsUser]  WITH CHECK ADD FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([Id_Counties])
REFERENCES [dbo].[Counties] ([Id_Counties])
GO
ALTER TABLE [dbo].[Counties]  WITH CHECK ADD FOREIGN KEY([Id_Province])
REFERENCES [dbo].[Province] ([Id_Province])
GO
ALTER TABLE [dbo].[PaymentsPerUser]  WITH CHECK ADD FOREIGN KEY([Id_Membership_Registration_Types])
REFERENCES [dbo].[MembershipRegistrationTypes] ([Id_Membership_Registration_Types])
GO
ALTER TABLE [dbo].[PaymentsPerUser]  WITH CHECK ADD FOREIGN KEY([Id_Payment_Type])
REFERENCES [dbo].[PaymentTypes] ([Id_Payment_Type])
GO
ALTER TABLE [dbo].[PaymentsPerUser]  WITH CHECK ADD FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[RoutinesPerUser]  WITH CHECK ADD FOREIGN KEY([Id_Machine])
REFERENCES [dbo].[GymMachines] ([Id_Machine])
GO
ALTER TABLE [dbo].[RoutinesPerUser]  WITH CHECK ADD FOREIGN KEY([Id_Routine])
REFERENCES [dbo].[GymRoutines] ([Id_Routine])
GO
ALTER TABLE [dbo].[RoutinesPerUser]  WITH CHECK ADD FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Roles] ([Id_Rol])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Id_Cities])
REFERENCES [dbo].[Cities] ([Id_Cities])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Id_Counties])
REFERENCES [dbo].[Counties] ([Id_Counties])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Id_Province])
REFERENCES [dbo].[Province] ([Id_Province])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Id_State])
REFERENCES [dbo].[UserState] ([Id_State])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Identification_Type_ID])
REFERENCES [dbo].[IdentificationTypes] ([Identification_Type_ID])
GO
ALTER TABLE [dbo].[ViewsPerRoles]  WITH CHECK ADD FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Roles] ([Id_Rol])
GO
USE [master]
GO
ALTER DATABASE [SteelBodyGym] SET  READ_WRITE 
GO



INSERT INTO [dbo].[Users]
           ([Id_Number]
           ,[Name]
           ,[Firstname]
           ,[LastName]
           ,[Birth_Date]
           ,[Gender]
           ,[Id_Rol]
           ,[Identification_Type_ID]
           ,[Id_State]
           ,[Id_Province]
           ,[Id_Counties]
           ,[Id_Cities]
           ,[Email]
           ,[Phone]
           ,[Password])
     VALUES
           ('304870221'
           ,'Ronny'
           ,'Aguilar'
           ,'Barahona'
           ,'1995-05-28'
           ,'Masculino'
           ,'558818D1-35D1-4124-95A6-61FF5C24295E'
           ,'4A5EF716-D6FF-4223-B017-82E119B41C6F'
           ,'8F14BA4C-CDDE-431F-92D1-66D2754B5E30'
           ,'1E894F4D-2A6C-44A6-9FC1-D61B36EC6BB2'
           ,'E5EE2DDF-3E68-40D5-A7B0-4FCAB80A70A0'
           ,'076F548B-4A58-4C0C-83EF-F8CB6753A737'
           ,'ronny199528@gmail.com'
           ,'85384263'
           ,'123456')
