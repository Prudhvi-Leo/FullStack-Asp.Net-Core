using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Models
{
    public class Employee
    {
        /* [Required(ErrorMessage = "Please Enter the First Name")]
        [BindNever]*/
        public string? FirstName { get; set; }
    }
}
