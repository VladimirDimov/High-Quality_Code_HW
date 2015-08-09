using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.Test
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void IsValidHandShouldReturnTrueWhenThereAreFiveDifferentCardsInTheHand()
        {
            var handsChecker = new PokerHandsChecker();

            var newHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            Assert.AreEqual(true, handsChecker.IsValidHand(newHand));
        }

        [TestMethod]
        public void IsValidHandShouldReturnFalseWhenThereAreOtherThanFiveCardsInTheHand()
        {
            var handsChecker = new PokerHandsChecker();

            var newHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            Assert.AreEqual(false, handsChecker.IsValidHand(newHand));
        }

        [TestMethod]
        public void IsValidHandShouldReturnFalseWhenThereAreFiveNonUniqueCardsInTheHand()
        {
            var handsChecker = new PokerHandsChecker();

            var newHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts)
            });

            Assert.AreEqual(false, handsChecker.IsValidHand(newHand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnTrueWhenThereIsFourOfAKind()
        {
            var handsChecker = new PokerHandsChecker();

            var newHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            Assert.AreEqual(true, handsChecker.IsFourOfAKind(newHand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseWhenThereIsNotFourOfAKind()
        {
            var handsChecker = new PokerHandsChecker();

            var newHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            Assert.AreEqual(false, handsChecker.IsFourOfAKind(newHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            var isFourOfAKind = handsChecker.IsFourOfAKind(invalidHand);
        }

        [TestMethod]
        public void IsHighCardShuldReturnTrueWhenMatchTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.King, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)              
            });

            var isHighCard = handsChecker.IsHighCard(hand);

            Assert.AreEqual(true, handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void IsHighCardShuldReturnFalseWhenNotMatchTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.King, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)              
            });

            var isHighCard = handsChecker.IsHighCard(hand);

            Assert.AreEqual(false, handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void IsHighCardShouldThrowWhenInvalidHand()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            var isFourOfAKind = handsChecker.IsHighCard(invalidHand);
        }

        [TestMethod]
        public void IsOnePairShuldReturnTrueWhenMatchTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), 
                new Card(CardFace.King, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)              
            });

            Assert.AreEqual(true, handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePairShuldReturnFalseWhenThePairIsPartOfBiggerHand()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)              
            });

            Assert.AreEqual(false, handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePairShuldReturnFalseWhenMissingPair()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.King, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)              
            });

            Assert.AreEqual(false, handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairhouldThrowWhenInvalidHand()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            var isOnePair = handsChecker.IsOnePair(invalidHand);
        }

        [TestMethod]
        public void IsTwoPairShouldReturnTrueWhenMathTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)              
            });

            Assert.AreEqual(true, handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void IsTwoPairShouldReturnFalseWhenThePairsArePartOfBiggerHand()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)              
            });

            Assert.AreEqual(false, handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void IsTwoPairShouldReturnFalseWhenNoTwoPairs()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.King, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)            
            });

            Assert.AreEqual(false, handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsTwoPairShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            var isTwoPair = handsChecker.IsTwoPair(invalidHand);
        }

        // IsThreeOfAKind
        [TestMethod]
        public void IsThreeOfAKindShouldReturnTrueWhenMathTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)              
            });

            Assert.AreEqual(true, handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindShouldReturnFalseWhenTheMatchIsAPartOfBiggerHand()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)              
            });

            Assert.AreEqual(false, handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindShouldReturnFalseWhenNoMatch()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.King, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)            
            });

            Assert.AreEqual(false, handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)              
            });

            var isThreeOfAKind = handsChecker.IsThreeOfAKind(invalidHand);
        }

        // IsFullHouse
        [TestMethod]
        public void IsFullHouseShouldReturnTrueWhenMathTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)              
            });

            Assert.AreEqual(true, handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFullHouseShouldReturnFalseWhenNoMatch()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)            
            });

            Assert.AreEqual(false, handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)              
            });

            var isFullHouse = handsChecker.IsFullHouse(invalidHand);
        }

        //IsStraight
        [TestMethod]
        public void IsStraightShouldReturnTrueWhenMathTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Two, CardSuit.Spades), // Repeated card
                new Card(CardFace.Three, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades)    
            });

            Assert.AreEqual(true, handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnFalseWhenStraightFlush()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Two, CardSuit.Spades), // Repeated card
                new Card(CardFace.Three, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)              
            });

            Assert.AreEqual(false, handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnFalseWhenNoMatch()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)            
            });

            Assert.AreEqual(false, handsChecker.IsStraight(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsStraightShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Two, CardSuit.Spades), // Repeated card
                new Card(CardFace.Three, CardSuit.Spades), // Repeatied card
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)              
            });

            var isStraight = handsChecker.IsStraight(invalidHand);
        }

        // IsStraightFlush
        [TestMethod]
        public void IsStraightFlushShouldReturnTrueWhenMathTheCriteria()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)    
            });

            Assert.AreEqual(true, handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnFalseWhenNoMatch()
        {
            var handsChecker = new PokerHandsChecker();

            var hand = new Hand(new[] { 
                new Card(CardFace.Ace, CardSuit.Spades), // Repeated card
                new Card(CardFace.Ace, CardSuit.Hearts), // Repeatied card
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)            
            });

            Assert.AreEqual(false, handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsStraightFlushShouldThrowWhenInvalidHandIsPassed()
        {
            var handsChecker = new PokerHandsChecker();

            var invalidHand = new Hand(new[] { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)              
            });

            var IsStraightFlush = handsChecker.IsStraightFlush(invalidHand);
        }
    }
}
