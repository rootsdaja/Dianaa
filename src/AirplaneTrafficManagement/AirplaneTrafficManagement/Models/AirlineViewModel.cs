using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Models
{
    public class AirlineViewModel
    {

        public int idAirline { get; set; }

        [DisplayName("Airline Company Name")]
        public string companyName { get; set; }
        public byte[] logo { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
 
    }
}