using AirplaneTrafficManagement.Database;
using AirplaneTrafficManagement.Models;
using AirplaneTrafficManagement.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Controllers
{
    public class TicketController : Controller
    {
        ITicketRepository _ticketRepository;
        IAirportRepository _airportRepo;
        IPassengerRepository _passengerRepo;
        IAirlineRepository _airlineRepo;
        IFlightRepository _flightRepo;

        public TicketController(ITicketRepository repo, IAirlineRepository airlineRepo,
            IAirportRepository airportRepo, IPassengerRepository passRepo, IFlightRepository flightRepo)
        {
            _ticketRepository = repo;
            _airlineRepo = airlineRepo;
            _passengerRepo = passRepo;
            _airportRepo = airportRepo;
            _flightRepo = flightRepo;
        }

           // GET: Ticket
        public ActionResult Index()
        {
            var model = new BookTicketsViewModel();
            model.TicketList = new List<BookTicketsViewModel>();   
 
            var ticketList = _ticketRepository.GetTickets();
            var airlineList = _airlineRepo.GetAirlines();
            var aiportList = _airportRepo.GetAirports();
            var passengerList = _passengerRepo.GetPassengers();
            var flightList = _flightRepo.GetFlights();

            foreach(var item in ticketList)
            {
                var bookingModel = new BookTicketsViewModel();

                bookingModel.idTicket = item.idTicket;
                bookingModel.roundTrip = item.roundTrip;
                bookingModel.seat = item.seat;
                bookingModel.@class = item.@class;

                model.TicketList.Add(bookingModel);
            }

            foreach(var item in airlineList)
            {
                var bookingModel = new BookTicketsViewModel();

                bookingModel.companyName = item.companyName;
                bookingModel.idAirline = item.idAirline;
                bookingModel.logo = item.logo;

                model.TicketList.Add(bookingModel);
            }

            foreach (var item in flightList)
            {
                var bookingModel = new BookTicketsViewModel();

                bookingModel.DepartureFromId = item.departureFrom ?? 0;
                bookingModel.ArrivalAtId = item.arriveAt ?? 0;
                bookingModel.departOn = item.departOn;
                bookingModel.returnOn = item.returnOn;

                model.TicketList.Add(bookingModel);
            }

            foreach(var item in airlineList)
            {
                var bookingModel = new BookTicketsViewModel();

                bookingModel.companyName = item.companyName;
                bookingModel.logo = item.logo;

                model.TicketList.Add(bookingModel);
            }

            foreach(var item in passengerList)
            {
                var bookingModel = new BookTicketsViewModel();

                bookingModel.adult = item.adult;
                bookingModel.children = item.children;
                bookingModel.infants = item.infants;

                model.TicketList.Add(bookingModel);
            }
            
            
            return View(model);
        }


        public ActionResult EditTicket(int id)
        {
            var getTicketById = _ticketRepository.GetTicketById(id);

            if(getTicketById == null)
            {
                return HttpNotFound();
            }

            var ticketModel = new TicketViewModel();

            ticketModel.idTicket = getTicketById.idTicket;
            ticketModel.seat = getTicketById.seat;
            ticketModel.availableTickets = getTicketById.availableTickets;
            ticketModel.totalTickets = getTicketById.totalTickets;
            ticketModel.@class = getTicketById.@class;
            ticketModel.roundTrip = getTicketById.roundTrip;

            return View("EditTicket", ticketModel);  
        }

        public ActionResult saveChanges(TicketViewModel model)
        {
            var ticket = new Ticket();

            ticket.idTicket = model.idTicket;
            ticket.seat = model.seat;
            ticket.availableTickets = model.availableTickets;
            ticket.totalTickets = model.totalTickets;
            ticket.@class = model.@class;
            ticket.roundTrip = model.roundTrip;

            _ticketRepository.EditTicketRepo(ticket);

            return RedirectToAction("Index", "Ticket");
        }

        public ActionResult CreateTicket()
       {
            return View("AddTicket", new TicketViewModel());
        }

        public ActionResult AddTicket(TicketViewModel model)
        {
            var ticket = new Ticket();

            ticket.idTicket = model.idTicket;
            ticket.seat = model.seat;
            ticket.availableTickets = model.availableTickets;
            ticket.totalTickets = model.totalTickets;
            ticket.@class = model.@class;
            ticket.roundTrip = model.roundTrip;

            _ticketRepository.InsertTicket(ticket);

            return RedirectToAction("Index", model);
        }

        public ActionResult DeleteTicket(int id)
        {
             _ticketRepository.DeleteTicket(id);

            return RedirectToAction("Index", "Ticket");
        }
    }
}