using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Models
{
    public class FlightViewModel
    {
       
        public int idFlight { get; set; }

        [Display(Name = "Departure From")]
        public int? departureFrom { get; set; }

        [Display(Name = "Arrive At")]
        public int? arriveAt { get; set; }

        [DisplayName("Depart On")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> departOn { get; set; }

        [DisplayName("Return On")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> returnOn { get; set; }

        public Nullable<int> idAirport { get; set; }
        public Nullable<int> idRoute { get; set; }

        public virtual Airport Airport { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public IEnumerable<Flight> FlightList { get; set; }
        public IEnumerable<Airport> AirportList { get; set; }

        public IEnumerable<SelectListItem> DepartureItems
        {
            get
            {
                return new SelectList(AirportList, "idAirport", "airportName");
            }
        }

        public IEnumerable<SelectListItem> ArrivalItems
        {
            get
            {
                return new SelectList(AirportList, "idFlight", "arriveAt");
            }
        }

        //[Display(Name = "Search")]
        //public string _searchValue { get; set; }
        
    }
}