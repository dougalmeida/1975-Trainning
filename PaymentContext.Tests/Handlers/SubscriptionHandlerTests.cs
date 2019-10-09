using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Steve";
            command.LastName = "Rogers";
            command.Document = "0123456789";
            command.Email = "firstavenger@marvel.com";
            command.BarCode = "0123456789";
            command.BoletoNumber = "0123456789";
            command.PaymentNumber = "123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Stanley Lee";
            command.PayerDocument = "000012345";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "onwer@marvel.com";
            command.Street = "qwerty";
            command.Number = "qwerty";
            command.Neighborhood = "qwerty hood";
            command.City = "qwerty city";
            command.State = "qy";
            command.Country = "USA";
            command.ZipCode = "123456789";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}