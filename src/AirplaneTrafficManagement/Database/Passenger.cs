
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
    
public partial class Passenger
{

    public Passenger()
    {

        this.Clients = new HashSet<Client>();

        this.Tickets = new HashSet<Ticket>();

    }


    public int idPassenger { get; set; }

    public Nullable<int> adult { get; set; }

    public Nullable<int> children { get; set; }

    public Nullable<int> infants { get; set; }

    public Nullable<int> idTicket { get; set; }



    public virtual ICollection<Client> Clients { get; set; }

    public virtual Ticket Ticket { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }

}

}
