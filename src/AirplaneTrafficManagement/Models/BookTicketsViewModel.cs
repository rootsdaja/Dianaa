using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace AirplaneTrafficManagement.Models
{
    public class BookTicketsViewModel
    {
        //Ticket
        public int idTicket { get; set; }
        public Nullable<int> idAirline { get; set; }
        [DisplayName("Seat Number")]
        public Nullable<int> seat { get; set; }
        [DisplayName("Available Tickets")]
        public Nullable<int> availableTickets { get; set; }
        [DisplayName("Total Tickets")]
        public Nullable<int> totalTickets { get; set; }
        public Nullable<int> idFlight { get; set; }
        [DisplayName("Class")]
        public string @class { get; set; }
        [DisplayName("Round trip")]
        public Nullable<bool> roundTrip { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }

        //Flight
        [Display(Name = "Departure From")]
        public int DepartureFromId { get; set; }
        [Display(Name = "Arrive At")]
        public int ArrivalAtId { get; set; }
        [DisplayName("Depart On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> departOn { get; set; }
        [DisplayName("Return On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> returnOn { get; set; }
        public Nullable<int> idAirport { get; set; }
        public Nullable<int> idRoute { get; set; }


        public virtual Airport DepartureFromAirport { get; set; }
        public virtual Airport ArrivalAtAirport { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        //Passenger
        public int idPassenger { get; set; }
        [DisplayName("Adult")]
        public Nullable<int> adult { get; set; }
        [DisplayName("Children")]
        public Nullable<int> children { get; set; }
        [DisplayName("Infants")]
        public Nullable<int> infants { get; set; }

        public virtual Ticket Ticket { get; set; }

        //Airline
        [DisplayName("Airline Company Name")]
        public string companyName { get; set; }
        public byte[] logo { get; set; }

       // public List<SelectListItem> AirlineList { get; set; }
        public List<BookTicketsViewModel> TicketList { get; set; }
    
    }
}