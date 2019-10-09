using System;
using Flunt.Notifications;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string TransactionCode { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public Document PayerDocument { get; set; }
        public Enums.EDocumentType PayerDocumentType { get; set; }
        public string  PayerEmail { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}