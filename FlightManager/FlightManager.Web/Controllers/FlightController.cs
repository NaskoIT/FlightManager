using FlightManager.Services.Interfaces;
using FlightManager.ViewModels.Flight;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult All() => View(flightService.All());

        [Authorize]
        public IActionResult Details(int id)
        {
            FlightDetailsViewModel model = flightService.GetById<FlightDetailsViewModel>(id);
            return View(model);
        }
    }
}
