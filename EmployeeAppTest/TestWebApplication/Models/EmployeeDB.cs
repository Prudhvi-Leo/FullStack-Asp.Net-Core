namespace TestWebApplication.Models
{
    public class EmployeeDB
    {
        public int EmployeeDBId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
