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
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;

        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Steve", "Rogers");
            _document = new Document("41014411033", EDocumentType.CPF);
            _email = new Email("firtavenger@marvel.com");
            _student = new Student(_name, _document, _email);
            _address = new Address("123 Street", "123", "Central Park", "New York", "NY", "USA", "10001");
            _subscription = new Subscription(null);            
        }

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

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Steve Rogers Inc.", _document, _address, _email);            
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);            
            
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Steve Rogers Inc.", _document, _address, _email);            
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Valid);
        }        
    }
}