using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Invalid Document"));
        }

        public string Number { get; private set; }
        public EDocumentType Type;

        private bool Validate()
        {
            //TODO - IMPLEMENT VALIDATION FOR EACH DOC TYPE
            if(Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;
            
            if(Type == EDocumentType.CPF && Number.Length == 11)
                return true;
            
            return false;
        }
    }    
}