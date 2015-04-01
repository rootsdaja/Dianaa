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

        //Prin constructorul asta, tu tot ce faci in controller, se ataseaza la constructor
        //si apoi la Interfata si din interfata in Repositoryul asociat interfetei
        public FlightController(IFlightRepository repo)
        {
            _flightRepo = repo;
        }

        // GET: Airplane
        public ActionResult Index()
        {
            var model = new FlightViewModel();
           // var airport = new AirportRepository();
            
           
            //model.FlightList = flightList;
            var flightList = _flightRepo.GetFlights();
            //var departList = airport.GetAirports();
            model.FlightList = flightList;
            //model.AirportList = departList;

            return View(model);
        }
 
        public ActionResult EditFlight(int id)
        {
            var getFlightById = _flightRepo.GetFlightById(id);

            if(getFlightById == null)
            {
                return HttpNotFound();
            }

            var flightModel = new FlightViewModel();

            flightModel.idFlight = getFlightById.idFlight;
            flightModel.departureFrom = getFlightById.departureFrom;
            flightModel.arriveAt = getFlightById.arriveAt;
            flightModel.departOn = getFlightById.departOn;
            flightModel.returnOn = getFlightById.returnOn;

            var flightList = _flightRepo.GetFlights();
            flightModel.FlightList = flightList;

            //var airportRepo = new AirportRepository();
            //airportRepo.GetAirports();


            return View("EditFlight", flightModel);  
        }

        public ActionResult SaveChanges(FlightViewModel model)
        {
            var flight = new Flight();

            flight.idFlight = model.idFlight;
            flight.departureFrom = model.departureFrom;
            flight.arriveAt = model.arriveAt;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;

            _flightRepo.EditFlightRepo(flight);

        

            return RedirectToAction("Index", "Flight");
        }

        public ActionResult CreateFlight()
       {
            return View("AddFlight", new FlightViewModel());
        }

        public ActionResult AddFlight(FlightViewModel model)
        {
            var flight = new Flight();

            flight.idFlight = model.idFlight;
            flight.departureFrom = model.departureFrom;
            flight.arriveAt = model.arriveAt;
            flight.departOn = model.departOn;
            flight.returnOn = model.returnOn;

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