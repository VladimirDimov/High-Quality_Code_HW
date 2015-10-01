using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.Collections.Generic;

namespace Phonebook.Tests
{
    [TestClass]
    public class AddPhoneTest
    {
        [TestMethod]
        public void AddNonExistingEntryShouldReturnTrue()
        {
            IPhonebookRepository repository = new PhonebookRepository();
            var result = repository.AddPhone("Pesho", new List<string>() { });
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddExistingEntryShouldReturnFalse()
        {
            IPhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Pesho", new List<string>() { });
            var result = repository.AddPhone("Pesho", new List<string>() { });
            Assert.AreEqual(false, result);
        }
    }
}
