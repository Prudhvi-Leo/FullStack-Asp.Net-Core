namespace TestWebApplication.Models
{
    public class SomeOtherService
    {
        //Create a reference variable of IStudentRepository
        private readonly IStudentRepository? _repository = null;
        //Initialize the variable through constructor
        public SomeOtherService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void SomeMethod()
        {
            //This Method is also going to use the StudentRepository Service
        }
    }
}
