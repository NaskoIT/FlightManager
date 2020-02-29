using FlightManager.InputModels.Reservation;
using FlightManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await reservationService.Create(model);
            return Redirect("/");
        }
    }
}
