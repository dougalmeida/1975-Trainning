using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        
        private IList<Student> _students;

        public StudentQueriesTest()
        {
            _students = new List<Student>();

            for(var i = 0; i <= 10; i++)
            {
                _students.Add(
                    new Student(
                        new Name("Student", i.ToString()), 
                        new Document($"1111111111{i}", EDocumentType.CPF), 
                    new Email($"std{i}@test.com")));
            }                
        }

        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("0123456789");
            var stdnt = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, stdnt);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }
    }
}