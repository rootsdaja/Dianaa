﻿using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class FlightRepository : IFlightRepository
    {
        private AirplaneTrafficEntities _context;

        //public FlightRepository(AirplaneTrafficEntities context)
        //{
        //    this.context = context;
        //}

        public FlightRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public List<Flight> GetFlightByDeparture(string departure)
        {
            var flight = _context.Flights.Where(f => f.departureFrom == departure).ToList();
            return flight;
        }

        public List<Flight> GetFlightByDepartureAndArrivalLocation(string depart, string arrive)
        {
            var flight = _context.Flights.Where(f => f.departureFrom == depart && f.arriveAt == arrive).ToList();
            return flight;
        }

        //public List<Flight> GetCityByCountry(string city, string country)
        //{
        //    var cityByCountry = _context.Flights.Where(c => c.Airport.city == city && c.Airport.country == country).ToList();
        //    return cityByCountry;
        //}

        public List<Flight> SearchFlightByDepartureAndArrival(string _searchValue)
        {
            var flight = _context.Flights.Where(f => f.departureFrom.StartsWith(_searchValue) && f.arriveAt.StartsWith(_searchValue)).ToList();
            return flight;
        }
  
        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertFlight(Flight flight)
        {
            _context.Flights.Add(flight);
        }

        public void DeleteFlight(int flightId)
        {
            Flight flight = _context.Flights.Find(flightId);
            _context.Flights.Remove(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}