using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class AirlineRepository : IAirlineRepository
    {
          private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public AirlineRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Airline> GetAirlines()
        {
            return _context.Airlines.ToList();
        }

        public Airline GetAirlineById(int id)
        {
            return _context.Airlines.Find(id);
        }

        public List<Airline> GetAirlineByCompanyName(string name)
        {
            var airline = _context.Airlines.Where(a => a.companyName == name).ToList();
            return airline;
        }

        public List<Airline> SearchAirlineByCompanyName(string _searchValue)
        {
            var airline = _context.Airlines.Where(a => a.companyName.StartsWith(_searchValue)).ToList();
            return airline;
        }
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
        }

        public void DeleteAirline(int airlineId)
        {
            Airline airline = _context.Airlines.Find(airlineId);
            _context.Airlines.Remove(airline);
        }

        public void UpdateAirline(Airline airline)
        {
            _context.Entry(airline).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    
    }
}