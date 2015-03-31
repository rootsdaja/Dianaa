using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class PassengerRepository : IPassengerRepository
    {
              private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

              public PassengerRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

           public IEnumerable<Passenger> GetPassengers()
        {
            return _context.Passengers.ToList();
        }

           public Passenger GetPassengerById(int id)
        {
            return _context.Passengers.Find(id);
        }

  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

           public void InsertPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }

           public void DeletePassenger(int Id)
        {
            Passenger passenger = _context.Passengers.Find(Id);
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
        }

           public void UpdatePassenger(Passenger passenger)
        {
            _context.Entry(passenger).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void EditPassengerRepo(Passenger passenger)
        {
            var passengerId = _context.Passengers.FirstOrDefault(f => f.idPassenger == passenger.idPassenger);

            passengerId.idPassenger = passenger.idPassenger;
            passengerId.adult = passenger.adult;
            passengerId.children = passenger.children;
            passengerId.infants = passenger.infants;

            _context.SaveChanges();
        }

    }
}