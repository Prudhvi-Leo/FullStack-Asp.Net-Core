
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestWebApplication.Models;
using TestWebApplication.ViewModels;

namespace TestWebApplication.StudentControllers
{
    //[Route("CommonPrefixStudent")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository? _repository = null;
        private readonly SomeOtherService? someOtherService = null;
        //Initialize the variable through constructor
        public StudentController(SomeOtherService service, IStudentRepository? repository)
        {
            someOtherService = service;
            _repository = repository;
        }
        public IActionResult Index()
        {
            List<Student>? allStudentDetails = _repository?.getAllSudent();
            return View(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _repository?.getStudentDetails(Id);
            return Json(studentDetails);
        }
        [Route("student/details/{studentID}")]
        public List<string> GetStudentCourses(int studentID)
        {
            //Real-Time you will get the courses from database, here we have hardcoded the data
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET Core", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET Core MVC", "C#.NET", "ADO.NET Core" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET Core WEB API", "C#.NET", "Entity Framework Core" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };

            return CourseList;
        }
        public ActionResult Display()
        {
            ViewBag.Title = "Student Details Page";
            ViewBag.Header= "Student Details";
            Student student = new Student()
            {
                Name = "James",
                Gender = 'M',
                RollNo = 7
            };
            /* var studentJsonFormat = JsonSerializer.Serialize(student);
             Student? s = JsonSerializer.Deserialize<Student>(studentJsonFormat);
             TempData["student"] = s;*/
            return RedirectToAction("StudentDetails");
        }
        public ViewResult StudentDetails()
        {
            Student student = new Student()
            {
                RollNo= 101,
                Name = "Dillip",
                Gender = 'M'
            };
            //Student Address
            Address address = new Address()
            {
                RollNo = 101,
                City = "Mumbai",
                PinCode = "400097"
            };
            //Creating the View model
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
            {
                Student = student,
                Address = address,
                Title = "Student Details Page",
                Header = "Student Details",
            };
            //Pass the studentDetailsViewModel to the view
            return View(studentDetailsViewModel);
        }
        public IActionResult parameter(int id)
        {
            Student? studentDetails = _repository?.getStudentDetails(id);
            return View(studentDetails);

        }
        [Route("abc")]
        [Route("abc/def")]
        public string TestMultipleActionAttribute()
        {
            return "hello world from TestMultipleActionAttribute";
        }
       
    }
}
