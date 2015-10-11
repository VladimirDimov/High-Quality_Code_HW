namespace Phonebook.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Loggers;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class ListEntriesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowWhenStartIndexIsNegative()
        {
            var phonebookRepository = new PhonebookRepository(new ConsoleLogger());
            phonebookRepository.AddPhone("Pesho", new List<string>() { "0888123456" });
            phonebookRepository.ListEntries(-1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowWhenEndIndexIsLargerThanTheNumberOfEntries()
        {
            var phonebookRepository = new PhonebookRepository(new ConsoleLogger());
            phonebookRepository.AddPhone("Pesho", new List<string>() { "0888123456" });
            phonebookRepository.ListEntries(0, 2);
        }

        [TestMethod]
        public void ShouldReturnProperNumberOfEntriesWhenValid()
        {
            var phonebookRepository = new PhonebookRepository(new ConsoleLogger());
            phonebookRepository.AddPhone("Pesho", new List<string>() { "0888123451" });
            phonebookRepository.AddPhone("Gosho", new List<string>() { "0888123452" });
            phonebookRepository.AddPhone("Tosho", new List<string>() { "0888123453" });
            var requestedEntries = phonebookRepository.ListEntries(0, 3);

            Assert.AreEqual(3, requestedEntries.Length);
        }
    }
}
