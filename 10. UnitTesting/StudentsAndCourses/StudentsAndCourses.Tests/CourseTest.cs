namespace StudentsAndCourses.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        private TestingConstants constants = new TestingConstants();

        [TestMethod]
        public void ExpectToThrowWhenInvallidCourseNameIsPassed()
        {
            foreach (var name in constants.invalidCourseNames)
            {
                try
                {
                    var newCourse = new Course(name);
                    Assert.Fail("An exception should have been thrown");
                }
                catch (Exception ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                }
            }
        }

        [TestMethod]
        public void ExpectedToCreateNewCourseWhenValidNameIsPassed()
        {
            foreach (var name in constants.validCourseNames)
            {
                var newCourse = new Course(name);
                Assert.IsInstanceOfType(newCourse, typeof(Course));
            }
        }

        [TestMethod]
        public void ExpectToBeAbleToAddNewStudentsToCourse()
        {
            var newCourse = new Course(constants.validCourseNames[0]);
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[0],
                constants.validStudentLastNames[0],
                constants.validStudentNumbers[0]));

            Assert.AreEqual(1, newCourse.GetStudents().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenStudentWithNonUniqueNumberIsBeingAdded()
        {
            var newCourse = new Course(constants.validCourseNames[0]);
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[0],
                constants.validStudentLastNames[0],
                constants.validStudentNumbers[0]));
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[1],
                constants.validStudentLastNames[1],
                constants.validStudentNumbers[0]));
        }

        [TestMethod]
        public void ExpectToRemoveStudentByNumber()
        {
            var newCourse = new Course(constants.validCourseNames[0]);
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[0],
                constants.validStudentLastNames[0],
                constants.validStudentNumbers[0]));
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[1],
                constants.validStudentLastNames[1],
                constants.validStudentNumbers[1]));

            newCourse.RemoveStudentByNumber(constants.validStudentNumbers[0]);

            Assert.AreEqual(1, newCourse.GetStudents().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenTryToRemoveStudentWithNumberNotInCourseStudents()
        {
            var newCourse = new Course(constants.validCourseNames[0]);
            newCourse.AddStudent(new Student(constants.validStudentFirstNames[0],
                constants.validStudentLastNames[0],
                20000));

            newCourse.RemoveStudentByNumber(25000);
        }
    }
}
