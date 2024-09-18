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

        public IActionResult Index()
        {
            var users = _service.GetAllUsers();

            return View(users);
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

        public IActionResult GoToUpdateUser(long id)
        {
            var user = _service.GetUserById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult GoToUpdateUser(UserModel user)
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

                    _service.UpdateUser(user);

                    TempData["SuccessMessage"] = Messages.Messages.CompletedUpdate;

                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult GoToViewUser(long id)
        {
            var user = _service.GetUserById(id);

            return View(user);
        }

        public IActionResult GoToDeleteUser(long id)
        {
            try
            {
                _service.DeleteUser(id);

                TempData["SuccessMessage"] = Messages.Messages.CompletedDelete;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult GoToResetPassword(long id)
        {
            try
            {
                var user = _service.GetUserById(id);

                return PartialView("_GoToResetPassword", user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult GoToResetPassword(UserModel user)
        {
            try
            {
                var password = user.Password.GenerateHash();

                user.Password = password;

                var userUpdated = _service.UpdatePassword(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
