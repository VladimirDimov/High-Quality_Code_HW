namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Phonebook.Loggers;

    [TestClass]
    public class AddPhoneTests
    {
        [TestMethod]
        public void ShouldBeAbleToAddValidEntries()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            bool isExistingEntry = phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });

            Assert.AreEqual(false, isExistingEntry);
        }

        [TestMethod]
        public void ShouldMergeNumbersIfEntryNameExists()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            bool isExistingEntry = phoneRepository.AddPhone("pesho", new List<string>() { "0877789101" });

            Assert.AreEqual(true, isExistingEntry);
        }

        [TestMethod]
        public void ShouldContainTwoEntriesWhenTwoDifferentEntriesAreAdded()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            phoneRepository.AddPhone("gosho", new List<string>() { "0877123457" });

            Assert.AreEqual(2, phoneRepository.Entries.Count);
        }

        [TestMethod]
        public void ShouldMergeTheNubersOfTheSameNameEntry()
        {
            var phoneRepository = new PhonebookRepository(new ConsoleLogger());
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123456" });
            phoneRepository.AddPhone("pesho", new List<string>() { "0877123457" });

            Assert.AreEqual(1, phoneRepository.Entries.Count);
        }
    }
}
