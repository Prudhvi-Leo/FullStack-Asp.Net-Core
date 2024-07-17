using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private List<Products> list = new List<Products>();
        public ProductsController()
        {
            list = new List<Products>()
            {
                new Products { ProductID =1, Name ="Products 1", Category = "Category 1", Description ="Description 1", Price = 10m},
                new Products { ProductID =2, Name ="Products 2", Category = "Category 1", Description ="Description 2", Price = 20m},
                new Products { ProductID =3, Name ="Products 3", Category = "Category 1", Description ="Description 3", Price = 30m},
                new Products { ProductID =4, Name ="Products 4", Category = "Category 2", Description ="Description 4", Price = 40m},
                new Products { ProductID =5, Name ="Products 5", Category = "Category 2", Description ="Description 5", Price = 50m},
                new Products { ProductID =6, Name ="Products 6", Category = "Category 2", Description ="Description 6", Price = 50m}
            };
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            try
            {
                //Based on the Category Fetch the Data from the database 
                //Here, we have hard coded the data
                List<Products> products = new List<Products>
                {
                    new Products{ ProductID = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                    new Products{ ProductID = 1002, Name = "Desktop", Description = "HP Desktop" },
                    new Products{ ProductID = 1003, Name = "Mobile", Description = "Apple IPhone" }
                };
                //Please uncomment the following two lines if you want see what happend when exception occurred
                //int a = 10, b = 0;
                //int c = a / b;
                return Json(products, options);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = ex.Message, StackTrace = ex.StackTrace, ExceptionType = "Internal Server Error" }, options)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };
             }
        }
        public IActionResult Details(int Id)
        
        {
            var ProductsDetails = list.FirstOrDefault(prd => prd.ProductID == Id);
           
            return View(ProductsDetails);
        }
        public  IActionResult ProductsComponent()
        {
            return View();
        }

        
    }
}
