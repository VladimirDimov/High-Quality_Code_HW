namespace StudentsAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        private TestingConstants constants = new TestingConstants();

        [TestMethod]
        public void ShouldCreateNewSchoolWithValidName()
        {
            foreach (var schoolName in constants.validSchoolNames)
            {
                School newSchool = new School(schoolName);

                Assert.IsInstanceOfType(newSchool, typeof(School));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenEmptyStringNameIsPassed()
        {
            School newSchool = new School("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenNullStringSchoolNameIsPassed()
        {
            School newSchool = new School(null);
        }

        [TestMethod]
        public void ExpectedExceptionWhenInvallidSchholNameIsPassed()
        {
            foreach (var name in constants.invalidSchoolNames)
            {
                try
                {
                    var newSchool = new School(name);
                    Assert.Fail("An exception should have been thrown");
                }
                catch (Exception ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                }
            }
        }

        [TestMethod]
        public void ExpectToIncreaseCoursesByOneWhenNewValidCourseIsAdded()
        {
            var newSchool = new School(constants.validSchoolNames[0]);
            newSchool.AddCourse(new Course(constants.validCourseNames[0]));
            Assert.AreEqual(1, newSchool.GetCourses().Count);
        }

        [TestMethod]
        public void ExpectToDecreseNumberOfCoursesByOneAfterRemovingAvailbaleCourse()
        {
            var newSchool = new School(constants.validSchoolNames[0]);
            foreach (var courseName in constants.validCourseNames)
            {
                newSchool.AddCourse(new Course(courseName));
            }

            int numberOfCoursesBeforeRemove = newSchool.GetCourses().Count;
            newSchool.RemoveCourse(constants.validCourseNames[0]);

            Assert.AreEqual(numberOfCoursesBeforeRemove - 1, newSchool.GetCourses().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenTryToRemoveUnavailableCourse()
        {
            var newSchool = new School(constants.validSchoolNames[0]);
            foreach (var courseName in constants.validCourseNames)
            {
                newSchool.AddCourse(new Course(courseName));
            }

            newSchool.RemoveCourse(constants.validCourseNames[0] + 'a');
        }
    }
}
