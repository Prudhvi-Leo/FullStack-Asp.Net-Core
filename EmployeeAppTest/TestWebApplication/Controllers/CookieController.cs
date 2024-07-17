using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class CookieController : Controller
    {
        const string CookieUserId = "UserId";
        const string CookieUserName = "UserName";
        MyCookieService _myCookieService;
        public CookieController(MyCookieService myCookieService)
        {
            _myCookieService = myCookieService;
        }
        public IActionResult Login()
        {
            //Let us assume the User is logged in and we need to store the user information in the cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, 
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddDays(7)
            };

            //Encrypt the Cookie Value
            string encryptedUserId = _myCookieService.Protect("1234567");
            //Store the Encrypted value in the Cookies Response Header
            Response.Cookies.Append(CookieUserId, encryptedUserId, cookieOptions);

            //Encrypt the Cookie Value
            string encryptedUserName = _myCookieService.Protect("pranaya@dotnettutotials.net");
            //Store the Encrypted value in the Cookies Response Header
            Response.Cookies.Append(CookieUserName, encryptedUserName, cookieOptions);

            //If you are coming to this page later,
            //it will also fetch the data from the Cookies Response Header
            string? encryptedUserNameValue = Request.Cookies[CookieUserName];
            if (encryptedUserNameValue != null)
            {
                ViewBag.UserName = _myCookieService.Unprotect(encryptedUserNameValue);
            };

            string? encryptedUserIdValue = Request.Cookies[CookieUserId];
            if (encryptedUserIdValue != null)
            {
                ViewBag.UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
            }

            return View();
        }

        public string About()
        {
            try
            {
                string? UserName = null;
                //Fetch the Encrypted Cookie from the Request Header
                string? encryptedUserNameValue = Request.Cookies[CookieUserName];
                if (encryptedUserNameValue != null)
                {
                    //Decrypt the Encrypted Value
                    UserName = _myCookieService.Unprotect(encryptedUserNameValue);
                };

                int? UserId = null;
                //Fetch the Encrypted Cookie from the Request Header
                string? encryptedUserIdValue = Request.Cookies[CookieUserId];
                if (encryptedUserIdValue != null)
                {
                    //Decrypt the Encrypted Value
                    UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
                }

                string Message = $"UserName: {UserName}, UserId: {UserId}";
                return Message;
            }
            catch (Exception ex)
            {
                return $"Error Occurred: {ex.Message}";
            }
        }

        public IActionResult Privacy()
        {
            //Fetch the Encrypted Cookie from the Request Header
            string? encryptedUserNameValue = Request.Cookies[CookieUserName];
            if (encryptedUserNameValue != null)
            {
                //Store the Decrypted Value in the ViewBag which we will display in the UI
                ViewBag.UserName = _myCookieService.Unprotect(encryptedUserNameValue);
            };

            //Fetch the Encrypted Cookie from the Request Header
            string? encryptedUserIdValue = Request.Cookies[CookieUserId];
            if (encryptedUserIdValue != null)
            {
                //Store the Decrypted Value in the ViewBag which we will display in the UI
                ViewBag.UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
            }
            return View();
        }

        public string DeleteCookie()
        {
            // Delete the Cookie From the Response Header, i.e., from the Browser.
            Response.Cookies.Delete(CookieUserId);
            Response.Cookies.Delete(CookieUserName);

            return "Cookies are Deleted";
        }
    }
}