//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirplaneTrafficManagement.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Airport
    {
        public Airport()
        {
            this.Flights = new HashSet<Flight>();
            this.Routes = new HashSet<Route>();
        }
    
        public int idAirport { get; set; }
        public string airportName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
