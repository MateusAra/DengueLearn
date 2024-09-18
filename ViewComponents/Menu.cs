using DengueLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DengueLearn.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext.Session.GetString("userSessionLogged");

            if (string.IsNullOrEmpty(session))
                return null;

            var user = JsonSerializer.Deserialize<UserModel>(session);

            return View(user);
        }
    }
}
