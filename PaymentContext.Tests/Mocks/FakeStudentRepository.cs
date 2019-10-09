using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscriprion(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if(document == "9999999999")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "hello@doug.io")
                return true;
            
            return false;
        }
    }
}
