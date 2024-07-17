using Microsoft.AspNetCore.Mvc;
using System;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee person)
        {
            if (ModelState.IsValid)
            {
                // Handle valid form submission (e.g., save to database)
                return RedirectToAction("Success");
            }
            return View(person);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
