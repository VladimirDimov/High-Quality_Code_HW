namespace StudentsAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        private TestingConstants constants = new TestingConstants();

        [TestMethod]
        public void ExpectToThrowWhenInvalidStudentFirstNameIsPassed()
        {
            foreach (var firstName in constants.invalidStudentNames)
            {
                try
                {
                    var newStudent = new Student(firstName, constants.validStudentLastNames[0], 150);
                    Assert.Fail("An exception should have been thrown.");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                }
            }
        }

        [TestMethod]
        public void ExpectToThrowWhenInvalidStudentLastNameIsPassed()
        {
            foreach (var lastName in constants.invalidStudentNames)
            {
                try
                {
                    var newStudent = new Student(constants.validStudentFirstNames[0], lastName, 150);
                    Assert.Fail("An exception should have been thrown");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                }
            }

        }

        [TestMethod]
        public void ExpectToCreateNewStudentWhenValidStudentFirstNameIsPassed()
        {
            foreach (var firstName in constants.validStudentFirstNames)
            {
                var newStudent = new Student(firstName, constants.validStudentLastNames[0], constants.validStudentNumbers[0]);
                Assert.IsInstanceOfType(newStudent, typeof(Student));
            }
        }

        [TestMethod]
        public void ExpectToCreateNewStudentWhenValidStudentLastNameIsPassed()
        {
            foreach (var lastName in constants.validStudentLastNames)
            {
                var newStudent = new Student(constants.validStudentFirstNames[0], lastName, constants.validStudentNumbers[0]);
                Assert.IsInstanceOfType(newStudent, typeof(Student));
            }
        }

        [TestMethod]
        public void ExpectToThrowWhenInvalidStudentNumberIsPassed()
        {
            foreach (var number in constants.invalidStudentNumbers)
            {
                try
                {
                    var newStudent = new Student(constants.validStudentFirstNames[0], constants.validStudentLastNames[0], number);
                    Assert.Fail("An exception should have been thrown");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                }
            }
        }

        [TestMethod]
        public void ExpectToCreateNewStudentWhenValidStudentNumberIsPassed()
        {
            foreach (var number in constants.validStudentNumbers)
            {
                var newStudent = new Student(constants.validStudentFirstNames[0], constants.validStudentLastNames[0], number);
            }
        }        
    }
}
