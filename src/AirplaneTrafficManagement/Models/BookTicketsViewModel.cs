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
        public int idTicket { get; set; }

        [DisplayName("Seat Number")]
        public Nullable<int> Seat { get; set; }

        [DisplayName("Class")]
        public string Class { get; set; }

        [DisplayName("Round trip")]
        public bool RoundTrip { get; set; }

        [Display(Name = "Departure From")]
        public int DepartureFromId { get; set; }

        [Display(Name = "Arrive At")]
        public int ArrivalAtId { get; set; }

        [DisplayName("Depart On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DepartOn { get; set; }
        [DisplayName("Return On")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ReturnOn { get; set; }

        public int AirlineId { get; set; }
        public int ClassId { get; set; }

        public int Adult { get; set; }
        public int Children { get; set; }
        public int Infant { get; set; }

    }
}