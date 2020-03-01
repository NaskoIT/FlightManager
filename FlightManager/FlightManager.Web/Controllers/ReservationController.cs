using FlightManager.Common.Mappings;
using FlightManager.InputModels.Reservation;
using FlightManager.Models.Enums;
using FlightManager.Services;
using FlightManager.Services.Interfaces;
using FlightManager.ViewModels.Flight;
using FlightManager.ViewModels.Reservation;
using FlightManager.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FlightManager.Common.GlobalConstants;

namespace FlightManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IFlightService flightService;
        private readonly IEmailSender emailSender;

        public ReservationController(
            IReservationService reservationService, 
            IFlightService flightService,
            IEmailSender emailSender)
        {
            this.reservationService = reservationService;
            this.flightService = flightService;
            this.emailSender = emailSender;
        }

        public IActionResult Create(int flightId)
        {
            var reservation = new ReservationInputModel();
            reservation.Passengers.Add(new ReservationPassangerInputModel());
            reservation.FlightId = flightId;
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationInputModel model)
        {
            int ecenomyTickets = model.Passengers.Count(p => p.TicketType == TicketType.Economy);
            int bussinesTickets = model.Passengers.Count(p => p.TicketType == TicketType.Bussines);
            int availableEconomyTickets = flightService.AvailableEconomyTickets(model.FlightId);
            int availableBusinessTickets = flightService.AvailableBussinesTickets(model.FlightId);
            if (availableEconomyTickets < ecenomyTickets)
            {
                ModelState.AddModelError(string.Empty, $"There are only {availableEconomyTickets} economy tickets left.");
            }
            if(availableBusinessTickets < bussinesTickets)
            {
                ModelState.AddModelError(string.Empty, $"There are only {availableBusinessTickets} business tickets left.");
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await reservationService.Create(model);
            await flightService.UpdateAvailableTickets(model.FlightId, ecenomyTickets, bussinesTickets);
            
            FlightViewModel flight = flightService.GetById<FlightViewModel>(model.FlightId);
            await SendConfirmationEmailsToPassengers(model.Passengers, flight);
            await SendEmailToClient(model.Client.Email, flight, model.Passengers);

            return Redirect("/");
        }

        public IActionResult Details(int id)
        {
            ReservationDetailsViewModel model = reservationService.GetById<ReservationDetailsViewModel>(id);
            return View(model);
        }

        private async Task SendConfirmationEmailsToPassengers(IEnumerable<ReservationPassangerInputModel> passengers, FlightViewModel flight)
        {
            const string EmailTemplateName = "PassengerConfirmationEmail";
            var model = new ReservationPassengerConfirmationEmailViewModel
            {
                Flight = flight
            };

            foreach (ReservationPassangerInputModel passenger in passengers)
            {
                model.Passenger = passenger.To<ReservationPassengerViewModel>();
                string body = await this.RenderViewAsync(EmailTemplateName, model, true);
                //Add smtp server credentials in appsettings.json and then uncomment next line
                //emailSender.Send(EmailCredentials.Email, passenger.Email, body, EmailSubjects.PassengerConfirmationEmail, true);
            }
        }

        private async Task SendEmailToClient(string email, FlightViewModel flight, IEnumerable<ReservationPassangerInputModel> passengers)
        {
            const string EmailTemplateName = "ClientConfirmationEmail";
            var model = new ReservationClientConfirmationEmailViewModel
            {
                Flight = flight,
                Passengers = passengers.Select(p => p.To<ReservationPassengerViewModel>())
            };

            string body = await this.RenderViewAsync(EmailTemplateName, model, true);
            //Add smtp server credentials in appsettings.json and then uncomment next line
            //emailSender.Send(EmailCredentials.Email, email, body, EmailSubjects.ClientConfirmationEmail, true);
        }

    }
}
