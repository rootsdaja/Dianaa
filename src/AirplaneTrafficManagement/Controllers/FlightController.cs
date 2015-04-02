using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Repo;
using AirplaneTrafficManagement.Models;

namespace AirplaneTrafficManagement.Controllers
{
    public class FlightController : Controller
    {
        IFlightRepository _flightRepo;
        IAirportRepository _airportRepo;

        public FlightController(IFlightRepository repo, IAirportRepository airportRepo)
        {
            _flightRepo = repo;
            _airportRepo = airportRepo;
        }
        
        // GET: Airplane
        public ActionResult Index()
        {
            var flightList = _flightRepo.GetFlights();

            return View(flightList);
        }
 
        public ActionResult EditFlight(int id)
        {
            var flight = _flightRepo.GetFlightById(id);
            var airportList = _airportRepo.GetAirports();

            if (flight == null)
            {
                return HttpNotFound();
            }

            var flightModel = new FlightViewModel();

            flightModel.idFlight = flight.idFlight;
            flightModel.DepartureFromId = flight.departureFrom ?? 0;
            flightModel.ArrivalAtId = flight.arriveAt ?? 0;
            flightModel.departOn = flight.departOn;
            flightModel.returnOn = flight.returnOn;


            ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
            ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);
    
            return View("EditFlight", flightModel);  
        }

        public ActionResult SaveChanges(FlightViewModel model)
        {
            var flight = _flightRepo.GetFlightById(model.idFlight);

            flight.departureFrom = model.DepartureFromId;
            flight.arriveAt = model.ArrivalAtId;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;

            _flightRepo.Save();

        

            return RedirectToAction("Index", "Flight");
        }

        public ActionResult CreateFlight()
       {
            return View("AddFlight", new FlightViewModel());
        }

        public ActionResult AddFlight(FlightViewModel model)
        {
            var flight = new Flight();
            var airportList = _airportRepo.GetAirports();

            //flight.idFlight = model.idFlight;
            //flight.departureFrom = model.DepartureFromId;
            //flight.arriveAt = model.ArrivalAtId;
            flight.departureFrom = model.DepartureFromId;
            //flight.Arrival.airportName = model.ArrivalAtAirport.airportName;
            flight.arriveAt = model.ArrivalAtId;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;

            ViewBag.DepartureFromId = new SelectList(airportList, "idAirport", "airportName", flight.departureFrom);
            ViewBag.ArrivalAtId = new SelectList(airportList, "idAirport", "airportName", flight.arriveAt);

            _flightRepo.InsertFlight(flight);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteFlight(int id)
        {
             _flightRepo.DeleteFlight(id);

            return RedirectToAction("Index", "Flight");
        }

   
    }
}