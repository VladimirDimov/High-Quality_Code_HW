namespace Phonebook.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Phonebook.Loggers;
    using System.Collections.Generic;

    [TestClass]
    public class ChangePhoneTests
    {
        [TestMethod]
        public void ShouldReturnProperNumberOfEntriesThatAreChangedWhenMoreThanOne()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            phoneRepository.AddPhone("gosho", new List<string>() { "0877123456" });
            var numberOfEntriesChanged = phoneRepository.ChangePhone("0877123456", "0877123457");

            Assert.AreEqual(2, numberOfEntriesChanged);
        }

        [TestMethod]
        public void ShouldReturnProperNumberOfEntriesThatAreChangedWhenAreOne()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            phoneRepository.AddPhone("gosho", new List<string>() { "0877123457" });
            var numberOfEntriesChanged = phoneRepository.ChangePhone("0877123456", "0877123458");

            Assert.AreEqual(1, numberOfEntriesChanged);
        }

        [TestMethod]
        public void ShouldReturnZeroWhenNoSuchEntry()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            phoneRepository.AddPhone("gosho", new List<string>() { "0877123457" });
            var numberOfEntriesChanged = phoneRepository.ChangePhone("0877123458", "0877123459");

            Assert.AreEqual(0, numberOfEntriesChanged);
        }
    }
}
