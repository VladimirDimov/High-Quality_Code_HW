using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.Test
{

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ToStringShouldReturnStringValue()
        {
            var newCard = new Card(CardFace.Ace, CardSuit.Clubs);
            var report = newCard.ToString();
            Assert.IsInstanceOfType(report, typeof(string));
        }

        [TestMethod]
        public void ToStringShouldReturnCorrectReport()
        {
            var newCard = new Card(CardFace.Ace, CardSuit.Spades);
            var report = newCard.ToString();
            var expectedResult = "Ace of spades";
            Assert.AreEqual(expectedResult, newCard.ToString());
        }
    }
}
