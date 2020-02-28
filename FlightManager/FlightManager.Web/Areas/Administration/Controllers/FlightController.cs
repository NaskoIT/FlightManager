using FlightManager.InputModels.Flight;
using FlightManager.Services.Interfaces;
using FlightManager.ViewModels.Flight;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FlightManager.Web.Areas.Administration.Controllers
{
    public class FlightController : AdministrationBaseController
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(FlightInputModel model)
        {
            if(model.LandingTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(FlightInputModel.LandingTime), "Landing time must be in the future!");
            }
            if (model.TakeOffTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(FlightInputModel.LandingTime), "Take off time must be in the future!");
            }
            if(model.LandingTime < model.TakeOffTime)
            {
                ModelState.AddModelError(nameof(FlightInputModel.LandingTime), "Take off time must be before landing time!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await flightService.Create(model);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            FlightInputModel model = flightService.GetById<FlightInputModel>(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightInputModel model, int id)
        {
            await flightService.Update(model, id);
            return RedirectToAction(nameof(Details), new { id });
        }

        public IActionResult Delete(int id)
        {
            FlightDetailsViewModel model = flightService.GetById<FlightDetailsViewModel>(id);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Details))]
        public IActionResult DeleteConfirm(int id)
        {
            flightService.Delete(id);
            return RedirectToAction(nameof(All));
        }
    }
}
