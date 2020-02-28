using FlightManager.Common.Mappings;
using FlightManager.InputModels.Employee;
using FlightManager.Models;
using FlightManager.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FlightManager.Common.GlobalConstants;

namespace FlightManager.Web.Areas.Administration.Controllers
{
    public class EmployeeController : AdministrationBaseController
    {
        private readonly UserManager<User> userManager;

        public EmployeeController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = model.To<User>();
            await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, Roles.Employee);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<User> users = await userManager.GetUsersInRoleAsync(Roles.Employee);
            return View(users.Select(u => u.To<EmployeeViewModel>()));
        }

        public async Task<IActionResult> Details(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<EmployeeDetailsViewModel>());
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<EmployeeEditInputModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditInputModel model)
        {
            User user = await userManager.FindByIdAsync(model.Id);
            user.Email = model.Email;
            user.UserName = model.Username;
            user.Address = model.Address;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.PersonalNumber = model.PersonalNumber;

            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Details), new { model.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<EmployeeDetailsViewModel>());
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteComfirm(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(All));
        }
    }
}
