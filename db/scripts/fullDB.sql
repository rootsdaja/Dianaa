USE [master]
GO
/****** Object:  Database [AirplaneTraffic]    Script Date: 3/19/2015 5:25:09 PM ******/
CREATE DATABASE [AirplaneTraffic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AirplaneTraffic', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AirplaneTraffic.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AirplaneTraffic_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AirplaneTraffic_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AirplaneTraffic] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirplaneTraffic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirplaneTraffic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AirplaneTraffic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirplaneTraffic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirplaneTraffic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirplaneTraffic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirplaneTraffic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirplaneTraffic] SET  MULTI_USER 
GO
ALTER DATABASE [AirplaneTraffic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirplaneTraffic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirplaneTraffic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirplaneTraffic] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AirplaneTraffic]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Airline](
	[idAirline] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [varchar](50) NULL,
	[logo] [image] NULL,
 CONSTRAINT [PK_Airline2] PRIMARY KEY CLUSTERED 
(
	[idAirline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Airport](
	[idAirport] [int] IDENTITY(1,1) NOT NULL,
	[airportName] [nvarchar](50) NULL,
	[city] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[state] [varchar](50) NULL,
 CONSTRAINT [PK_Airport2] PRIMARY KEY CLUSTERED 
(
	[idAirport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Client]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [int] NULL,
	[city] [varchar](50) NULL,
	[idUserType] [int] NULL,
	[idPassenger] [int] NULL,
	[idTicket] [int] NULL,
 CONSTRAINT [PK_Client2] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flight](
	[idFlight] [int] IDENTITY(1,1) NOT NULL,
	[departureFrom] [varchar](50) NULL,
	[arriveAt] [varchar](50) NULL,
	[departOn] [date] NULL,
	[returnOn] [date] NULL,
	[time] [time](7) NULL,
	[idAirport] [int] NULL,
	[idRoute] [int] NULL,
	[idAirline] [int] NULL,
 CONSTRAINT [PK_Flight2] PRIMARY KEY CLUSTERED 
(
	[idFlight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[idPassenger] [int] IDENTITY(1,1) NOT NULL,
	[adult] [int] NULL,
	[children] [int] NULL,
	[infants] [int] NULL,
 CONSTRAINT [PK_Passenger2] PRIMARY KEY CLUSTERED 
(
	[idPassenger] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Route]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[idRoute] [int] IDENTITY(1,1) NOT NULL,
	[leavingFrom] [nvarchar](50) NULL,
	[goingTo] [nvarchar](50) NULL,
	[leavingHour] [time](7) NULL,
	[arrivalHour] [time](7) NULL,
	[idAirport] [int] NULL,
 CONSTRAINT [PK_Route2] PRIMARY KEY CLUSTERED 
(
	[idRoute] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ticket](
	[idTicket] [int] IDENTITY(1,1) NOT NULL,
	[seat] [int] NULL,
	[availableTickets] [int] NULL,
	[totalTickets] [int] NULL,
	[class] [varchar](50) NULL,
	[roundTrip] [bit] NULL,
	[idAirline] [int] NULL,
	[idFlight] [int] NULL,
 CONSTRAINT [PK_Ticket2] PRIMARY KEY CLUSTERED 
(
	[idTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 3/19/2015 5:25:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[idUserType] [int] IDENTITY(1,1) NOT NULL,
	[admin] [bit] NULL,
 CONSTRAINT [PK_UserType2] PRIMARY KEY CLUSTERED 
(
	[idUserType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Passenger] FOREIGN KEY([idPassenger])
REFERENCES [dbo].[Passenger] ([idPassenger])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Passenger]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Ticket] FOREIGN KEY([idTicket])
REFERENCES [dbo].[Ticket] ([idTicket])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Ticket]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_UserType] FOREIGN KEY([idUserType])
REFERENCES [dbo].[UserType] ([idUserType])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_UserType]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airline] FOREIGN KEY([idAirline])
REFERENCES [dbo].[Airline] ([idAirline])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airline]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airport] FOREIGN KEY([idAirport])
REFERENCES [dbo].[Airport] ([idAirport])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airport]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Route] FOREIGN KEY([idRoute])
REFERENCES [dbo].[Route] ([idRoute])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Route]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Airport] FOREIGN KEY([idAirport])
REFERENCES [dbo].[Airport] ([idAirport])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Airport]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Airline] FOREIGN KEY([idAirline])
REFERENCES [dbo].[Airline] ([idAirline])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Airline]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Flight] FOREIGN KEY([idFlight])
REFERENCES [dbo].[Flight] ([idFlight])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Flight]
GO
USE [master]
GO
ALTER DATABASE [AirplaneTraffic] SET  READ_WRITE 
GO
