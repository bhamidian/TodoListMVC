using MaktabToDoList.Domain.Core.User.Contracts.ApplicationService;
using MaktabToDoList.EndPoints.MVC.Models.ViewModels;
using MaktabToDoList.Infrastructure.EFCore.InMemoryDatabase;
using Microsoft.AspNetCore.Mvc;

namespace MaktabToDoList.EndPoints.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly INormalUserAppService _normalUserAppService;

        public AccountController(INormalUserAppService normalUserAppService) =>
            _normalUserAppService = normalUserAppService;

        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserAuthenticationViewModel());
        }

        [HttpPost]
        public IActionResult Login(UserAuthenticationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var login = _normalUserAppService.Login(model.UserName, model.Password);

            if (login.IsSuccess)
            {
                InMemory.OnlineUser.UserName = login.Data.UserName;

                InMemory.OnlineUser.Id = login.Data.Id;

                return RedirectToAction("Index", "TaskItem");
            }
            TempData["Message"] = login.Message;

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserAuthenticationViewModel());
        }

        [HttpPost]
        public IActionResult Register(UserAuthenticationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var register = _normalUserAppService.Register(model.UserName, model.Password);

            if (register.IsSuccess)
                return View();

            TempData["Message"] = register.Message;

            return RedirectToAction("Login");
        }
    }
}
