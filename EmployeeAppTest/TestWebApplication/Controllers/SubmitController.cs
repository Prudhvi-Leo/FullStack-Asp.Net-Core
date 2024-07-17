using Microsoft.AspNetCore.Mvc;
using System;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class SubmitController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // POST: Process the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(SubmitForm model)
        {
            if (ModelState.IsValid)
            {
                // Process your model here (e.g., save to database)

                // Store a message in TempData
                TempData["SuccessMessage"] = "Form submitted successfully!";

                // Redirect to a GET method
                return RedirectToAction(nameof(Success));
            }

            // If model state is invalid, show the form again
            return View("Index", model);
        }

        // GET: Success page
        public IActionResult Success()
        {
            return View();
        }

    }
}
