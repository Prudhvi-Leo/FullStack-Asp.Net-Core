using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{

    public class UserProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SkillsList = new SelectList(new List<string> { "C#", "JavaScript", "Python", "SQL Server", "AWS" });
            ViewBag.PreferenceList = new SelectList(new List<string> { "Email", "SMS", "Phone Call", "WhatsApp" });
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                // Save userProfile to the database or process it further here
                // For demonstration, just redirect back to the form with a success message
                TempData["Success"] = "UserProfile submitted successfully!";
                return RedirectToAction("Index");
            }
            // If we got this far, something failed; redisplay form
            ViewBag.SkillsList = new SelectList(new List<string> { "C#", "JavaScript", "Python", "SQL Server", "AWS" });
            ViewBag.PreferenceList = new SelectList(new List<string> { "Email", "SMS", "Phone Call", "WhatsApp" });
            return View(userProfile);
        }
        public IActionResult FormSubmissionOne()
        {
            return View();
        }
        [HttpGet]
        public string FormSubmission(IFormCollection form)
        {
            string username = form["username"].ToString();
            string collegename = form["clgname"].ToString();
            return $"my name is : {username} and iam from {collegename} college";
        }
        [HttpPost]
        public string FromSubmissionModelBinding([FromForm] User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    return $"my name is : {user.username} and iam from {user.clgname} college";
                }
                else
                {
                    return "Details Missing";
                }
            }
            return "some error occured ";
        }
        [HttpGet]
        public string formQueryExample([FromQuery] User user)
        {
              return $"my name is : {user.username} and iam from {user.clgname} college";
        }
        [HttpPost]
        [Route("/userprofile/formRouteExample/{id}")]
        public IActionResult formRouteExample([FromRoute] int id) {
            var customUser = new List<dynamic>()
                {
                    new { id = 100, name = "prudhvi" },
                    new { id = 101, name = "john" }
                };
           

            return Ok(customUser.FirstOrDefault(u => u.id == id));
        }
        [HttpPost("/v1/user/")]
        public string FromBodyExample([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                return $"{user.username} {user.clgname}";
            }
            return $"some error occured";
        }
        [HttpGet("user/getdetails")]
        public IActionResult GetDetails([ModelBinder(typeof(CommaSeparatedModelBinder))] List<int> Ids)
        {
            return Ok(Ids);
        }
        [HttpGet("data/{country}")]
        public IActionResult GetComplexUserData([ModelBinder(typeof(ComplexUserModelBinder))] ComplexUser user)
        {
            // Your logic...
            return Ok(user);
        }

    }
}
