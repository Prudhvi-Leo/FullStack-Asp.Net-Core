using Microsoft.AspNetCore.Mvc;

namespace TestWebApplication.Models
{
    public class SessionController : Controller
    {
        const string SessionUserId = "_UserId";
        const string SessionUserName = "_UserName";
        public IActionResult Index()
        {
            //Let assume the User is logged in and we need to store the user information in the session
            //Storing Data into Session using SetString and SetInt32 method
            HttpContext.Session.SetString(SessionUserName, "pranaya@dotnettutotials.net");
            HttpContext.Session.SetInt32(SessionUserId, 1234567);
            return View();
        }

        public string About()
        {
            //Accessing the Session Data inside a Method
            string? UserName = HttpContext.Session.GetString(SessionUserName);
            int? UserId = HttpContext.Session.GetInt32(SessionUserId);

            string Message = $"UserName: {UserName}, UserId: {UserId}";
            return Message;
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
