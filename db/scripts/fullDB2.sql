USE [AirplaneTraffic]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 4/8/2015 10:30:31 AM ******/
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
/****** Object:  Table [dbo].[Airport]    Script Date: 4/8/2015 10:30:31 AM ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 4/8/2015 10:30:31 AM ******/
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
	[Id] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 4/8/2015 10:30:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[idFlight] [int] IDENTITY(1,1) NOT NULL,
	[departOn] [date] NULL,
	[returnOn] [date] NULL,
	[idAirport] [int] NULL,
	[idRoute] [int] NULL,
	[idAirline] [int] NULL,
	[departureFrom] [int] NULL,
	[arriveAt] [int] NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[idFlight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 4/8/2015 10:30:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[idPassenger] [int] IDENTITY(1,1) NOT NULL,
	[adult] [int] NULL,
	[children] [int] NULL,
	[infants] [int] NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[idPassenger] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Route]    Script Date: 4/8/2015 10:30:31 AM ******/
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
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[idRoute] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 4/8/2015 10:30:31 AM ******/
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
	[idPassenger] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[idTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 4/8/2015 10:30:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[idUserType] [int] IDENTITY(1,1) NOT NULL,
	[admin] [bit] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
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
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airport] FOREIGN KEY([departureFrom])
REFERENCES [dbo].[Airport] ([idAirport])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airport]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airport1] FOREIGN KEY([arriveAt])
REFERENCES [dbo].[Airport] ([idAirport])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airport1]
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
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Passenger] FOREIGN KEY([idPassenger])
REFERENCES [dbo].[Passenger] ([idPassenger])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Passenger]
GO
