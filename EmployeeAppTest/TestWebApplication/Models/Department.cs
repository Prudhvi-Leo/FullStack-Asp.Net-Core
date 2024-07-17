namespace TestWebApplication.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<EmployeeDB> Employees { get; set; }
    }
}
