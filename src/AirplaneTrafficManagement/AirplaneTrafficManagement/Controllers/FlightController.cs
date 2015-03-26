using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Repo;

namespace AirplaneTrafficManagement.Controllers
{
    public class FlightController : Controller
    {
        IFlightRepository _flightRepo;

        public FlightController(IFlightRepository repo)
        {
            _flightRepo = repo;
        }

        // GET: Airplane
        public ActionResult Index()
        {
            var flightList = _flightRepo.GetFlights();
            return View(flightList);
        }

        //public ActionResult Browse(string city)
        //{
        //    var flightModel = dbEntities.Flights.Include("City")
        //        .Single(c => c.departureFrom == city);

        //    return View(flightModel);
        //}
    }
}