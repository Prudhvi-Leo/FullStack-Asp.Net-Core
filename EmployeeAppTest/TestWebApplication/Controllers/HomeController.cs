using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using TestWebApplication.Models;

namespace TestWebApplication.StudentControllers
{
    public class HomeController : Controller
    {
        private int count = 0;
        public IActionResult Index()
        {
            return View();           
        }

        [CustomExceptionFilter]
        public ActionResult ErrorHandle()
        {
            int x = 10;
            int y = 0;
            int z = x / y;
            return View();
        }
        public IActionResult AjaxTest(int IDValue)
        {
            Products product = new Products()
            {
                ProductID = IDValue,
                Name = "Test Product",
            };
            return PartialView("_ProductPartialView", product);
        }
        public IActionResult Details()
        {
            List<Products> list = new List<Products>()
            {
                new Products { ProductID =1, Name ="Products 1", Category = "Category 1", Description ="Description 1", Price = 10m},
                new Products { ProductID =2, Name ="Products 2", Category = "Category 1", Description ="Description 2", Price = 20m},
                new Products { ProductID =3, Name ="Products 3", Category = "Category 1", Description ="Description 3", Price = 30m},
                new Products { ProductID =4, Name ="Products 4", Category = "Category 2", Description ="Description 4", Price = 40m},
                new Products { ProductID =5, Name ="Products 5", Category = "Category 2", Description ="Description 5", Price = 50m},
                new Products { ProductID =10, Name ="Products 6", Category = "Category 2", Description ="Description 6", Price = 50m}
            };
            return Json(list);
        }
        public IActionResult ContactUs()
        {
            string customContent = "Custom content with specific settings.";
            return new ContentResult
            {
                Content = customContent,
                ContentType = "text/plain",
                StatusCode = 200, // OK status code
            };
        }
        public IActionResult AboutUs(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        public string TestToken()
        {
            return "hello world from testToken from home";
        }
        public IActionResult FilesResult()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PdfFile\\" + "sample.pdf";
            Console.WriteLine(filePath);
            //Convert to Byte Array
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //Return the Byte Array
            return File(fileBytes, "application/pdf", "Infosys_Certification.pdf");
        }
        public IActionResult RedirectToChrome()
        {
            return Redirect("https://localhost:7102/home/index");
        }
        public IActionResult RedirectRoutePartTwo(int value)
        {
            return RedirectToRoute(new { Controller = "home", Action = "RedirectToChrome" });
        }
        public IActionResult RedirectRoute()
        {
            return RedirectToRoute("RedirectRouteParmeterRoute", new {name ="prudhvi" , age=24});

        }
        public string RedirectRouteParmeter(string name,int age)
        {
            return "hello myself "+ name + " and my age is " + age;        
        }
        public IActionResult GetPerson()
        {
            var person = new { FirstName = "Pranaya", LastName = "Rout", Age = 30 };
            var result = new ObjectResult(person)
            {
                StatusCode = 201, // Created status code
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
                {
                   // "application/json", // JSON content type
                    "application/xml" // XML content type
                }
            };
            return result;
        }
        public IActionResult HtmlTaggersTextBox()
        {
            Products products = new Products()
            {
                ProductID =1, Name ="Products 1", Category = "Category 1", Description ="Description 1", Price = 10m
               
            };
            return View(products);
        }
    }
}
