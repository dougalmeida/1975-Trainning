using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddStudentSubscription()
        {
            var subscription = new Subscription(null);
            var name = new Name("Douglas", "Almeida");            

            var document = new Document("1234567989", EDocumentType.CPF);
            var email = new Email("teste@teste.com");
            var student = new Student(name, document, email);
            student.AddSubscription(subscription);           
        }
    }
}