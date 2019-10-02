using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenCnpjIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCnpjIsvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCpfIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCpfIsvalid()
        {
            Assert.Fail();
        }
    }
}