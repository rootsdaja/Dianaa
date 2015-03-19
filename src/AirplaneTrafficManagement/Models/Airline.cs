using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class Airline
    {
        [Name=""]
        public int idAirline { get; set; }
        public string companyName { get; set; }
        public byte[] logo { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public class Airport
    {
        public int idAirport { get; set; }
        public string airportName { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }

    public partial class Client
    {
        public int idClient { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<int> phone { get; set; }
        public string city { get; set; }
        public Nullable<int> idUserType { get; set; }
        public Nullable<int> idPassenger { get; set; }
        public Nullable<int> idTicket { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual UserType UserType { get; set; }
    }

    public class Flight
    {
        public int idFlight { get; set; }
        public string departureFrom { get; set; }
        public string arriveAt { get; set; }
        public Nullable<System.DateTime> departOn { get; set; }
        public Nullable<System.DateTime> returnOn { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
        public Nullable<int> idAirport { get; set; }
        public Nullable<int> idRoute { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public class Passenger
    {
       public int idPassenger { get; set; }
       public Nullable<int> adult { get; set; }
       public Nullable<int> children { get; set; }
       public Nullable<int> infants { get; set; }
    
       public virtual ICollection<Client> Clients { get; set; }
    }

    public class Route
    {
        public int idRoute { get; set; }
        public string leavingFrom { get; set; }
        public string goingTo { get; set; }
        public Nullable<System.TimeSpan> leavingHour { get; set; }
        public Nullable<System.TimeSpan> goingHour { get; set; }
        public Nullable<int> idAirport { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }

    public class Ticket
    {
        public int idTicket { get; set; }
        public Nullable<int> idAirline { get; set; }
        public Nullable<int> seat { get; set; }
        public Nullable<int> availableTickets { get; set; }
        public Nullable<int> totalTickets { get; set; }
        public Nullable<int> idFlight { get; set; }
        public string @class { get; set; }
        public Nullable<bool> roundTrip { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual Flight Flight { get; set; }
    }

    public class UserType
    {

        public int idUserType { get; set; }
        public string regularUser { get; set; }
        public string admin { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}