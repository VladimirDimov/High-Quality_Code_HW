using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Santase.Logic.Cards;
using Santase.Logic;

namespace Santase.Test
{
    public class DeckTests
    {
        [Test]
        public void ShouldBeAbleToCreateNewDeck()
        {
            var newDeck = new Deck();
            Assert.AreEqual(typeof(Deck), newDeck.GetType());
        }

        [Test]
        public void NewDeckShouldContain24Cards()
        {
            var newDeck = new Deck();
            Assert.AreEqual(24, newDeck.CardsLeft);           
        }

        [Test]
        public void ShouldReturnNextCard()
        {
            var newDeck = new Deck();
            var nextCard = newDeck.GetNextCard();
            Assert.AreEqual(typeof(Card), nextCard.GetType());
        }

        [Test]
        public void DeckCardsMustDecreaseByOneAfterReturningNextCard()
        {
            var newDeck = new Deck();
            newDeck.GetNextCard();
            Assert.AreEqual(23, newDeck.CardsLeft);
        }

        [ExpectedException(typeof(InternalGameException))]
        public void ShouldThrowWhenTryToGetNextCardFromEmptyDeck()
        {
            var newDeck = new Deck();
            var initialNumberOfCards = newDeck.CardsLeft;
            for (int i = 0; i < initialNumberOfCards + 1; i++)
            {
                newDeck.GetNextCard();
            }
        }

        [Test]
        public void ShouldReturnTrumpCard()
        {
            var newDeck = new Deck();
            var trumpCard = newDeck.GetTrumpCard;
            Assert.AreEqual(typeof(Card), trumpCard.GetType());
        }

        [Test, Combinatorial]
        public void ShouldBeAbleToChangeTheTrumpCardToAnyPossibleCard(
           [Values(CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade)] CardSuit cardSuit,
            [Values(CardType.Nine, CardType.Ten, CardType.Jack, CardType.Queen, CardType.King, CardType.Ace)]CardType cardType)
        {
            var newDeck = new Deck();
            newDeck.ChangeTrumpCard(new Card(cardSuit, cardType));
            var trumpCard = newDeck.GetTrumpCard;
            Assert.AreEqual(cardSuit, trumpCard.Suit);
            Assert.AreEqual(cardType, trumpCard.Type);
        }
    }
}
