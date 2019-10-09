using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateSubscriprion(Student student);
    }
}