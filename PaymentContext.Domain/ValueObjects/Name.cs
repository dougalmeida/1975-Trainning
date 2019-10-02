using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", "Invalid First Name");
                
            if(string.IsNullOrEmpty(lastName))
                AddNotification("Name.LastName", "Invalid Last Name");

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "First Name must have at least 3 characters")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "First Name must have at maximum 40 characters")
                .HasMinLen(LastName, 3, "Name.LastName", "Last Name must have at least 3 characters"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}