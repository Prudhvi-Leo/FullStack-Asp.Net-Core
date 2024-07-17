namespace TestWebApplication.Models
{
    public interface IStudentRepository
    {
        public Student getStudentDetails(int id);
        public List<Student> getAllSudent();
    }
}
