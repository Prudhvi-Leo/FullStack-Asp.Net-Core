using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Models
{
    public class User
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? clgname { get; set; }
    }
}
