using DengueLearn.Messages;
using DengueLearn.Models;
using DengueLearn.Services.Interfaces;
using DengueLearn.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DengueLearn.Controllers
{
    public class LoginController : Controller
    {
        private readonly IService _service;

        public LoginController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            if (_service.GetUserSession() != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _service.GetUserByEmail(login.Email);

                    var password = login.Password.GenerateHash();

                    if (user == null || user.Password != password)
                        throw new Exception(Messages.Messages.LoginError);

                    _service.AddUserSession(user);

                    return RedirectToAction("Index", "Home");
                }
                return View("Index", login);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult GoToResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GoToResetPassword(ResetPasswordModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _service.GetUserByEmail(model.Email);

                    var newPassword = $"{Guid.NewGuid().ToString()[..8]}";

                    var message = "Olá! Sua senha foi redefinida. \n"
                        + "Sua nova senha é: " + newPassword;

                    var sendMail = _service.SendEmail(model.Email, "Sua nova senha!", message);

                    user.Password = newPassword.GenerateHash();

                    _service.UpdatePassword(user);

                    TempData["SuccessMessage"] = Messages.Messages.ResetSuccess;

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult SignOut()
        {
            _service.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }
    }
}
