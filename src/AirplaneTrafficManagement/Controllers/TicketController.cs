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

        public TicketController(ITicketRepository repo)
        {
            _ticketRepository = repo;
        }

           // GET: Ticket
        public ActionResult Index()
        {
            var model = new TicketViewModel();
            model._ticketList = new List<TicketViewModel>();

            var ticket = new Ticket();
            var ticketListRepo = _ticketRepository.GetTickets();

            foreach(var item in ticketListRepo)
            {
                var ticketModel = new TicketViewModel();

                ticketModel.idTicket = item.idTicket;
                ticketModel.seat = item.seat;
                ticketModel.availableTickets = item.availableTickets;
                ticketModel.totalTickets = item.totalTickets;
                ticketModel.@class = item.@class;
                ticketModel.roundTrip = item.roundTrip;     
                
                model._ticketList.Add(ticketModel);
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