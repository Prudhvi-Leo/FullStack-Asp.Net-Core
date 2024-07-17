using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Models
{
     public class UserProfile
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Name Field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Biography Field is Required")]
        public string Biography { get; set; }
        public string Gender { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
        public bool NewsLetter { get; set; }
        public string Preference { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
