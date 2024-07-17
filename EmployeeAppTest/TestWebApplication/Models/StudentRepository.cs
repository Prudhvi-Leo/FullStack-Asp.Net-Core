using Microsoft.AspNetCore.Mvc;

namespace TestWebApplication.Models
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
            string filePath = @"C:\Prudhvi\C# DEV\C-Advance-Concept-Codes\EmployeeAppTest\TestWebApplication\Logs\Log.txt";
            string contentToWrite = $"StudentRepository Object Created: @{DateTime.Now.ToString()}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(contentToWrite);
            }
        }
        public List<Student> DataSource()
        {
            return new List<Student>() {
                new Student(){RollNo = 1 , Gender = 'M' , Name ="abc"},
                 new Student(){RollNo = 2 , Gender = 'F' , Name ="abcc"},
                  new Student(){RollNo = 3, Gender = 'F' , Name ="abce"},
                   new Student(){RollNo = 4 , Gender = 'M' , Name ="abfc"},
                 new Student(){RollNo = 5, Gender = 'M' , Name ="abcs"},
            };
        }
        public Student getStudentDetails(int id)
        {
            return DataSource().FirstOrDefault(student => student.RollNo == id);
        }
        public List<Student> getAllSudent()
        {
            return DataSource();
        }
    }
}
