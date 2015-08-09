using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Test
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void ToStringShouldReturnStringValue()
        {
            var cardsOfHand = new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds)
            };

            Hand newHand = new Hand(cardsOfHand);

            Assert.IsInstanceOfType(newHand.ToString(), typeof(string));
        }

        [TestMethod]
        public void ToStringShouldReturnCorrectValueWhenValidHand()
        {
            var cardsOfHand = new [] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds)
            };

            var cardsOfHandAsStringValues = cardsOfHand.Select(x => x.ToString());

            Hand newHand = new Hand(cardsOfHand);
            var handReport = newHand.ToString();
            var expectedReport = "[" + String.Join(" | ", cardsOfHandAsStringValues) + "]";

            Assert.AreEqual(expectedReport, newHand.ToString());
        }
    }
}
