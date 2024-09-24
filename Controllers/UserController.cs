using DengueLearn.Models;
using DengueLearn.Services.Interfaces;
using DengueLearn.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DengueLearn.Controllers
{
    public class UserController : Controller
    {
        private readonly IService _service;

        public UserController(IService service)
        {
            _service = service;
        }

        public IActionResult GoToAddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GoToAddUser(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userExists = _service.GetUserByEmail(user.Email);

                    if (userExists != null)
                    {
                        ModelState.AddModelError("UserName", Messages.Messages.UserNameExists);
                        return View(user);
                    }

                    var password = user.Password.GenerateHash();

                    user.Password = password;

                    _service.AddUser(user);

                    TempData["SuccessMessage"] = Messages.Messages.CompletedRegister;

                    return RedirectToAction("Index", "Login");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
