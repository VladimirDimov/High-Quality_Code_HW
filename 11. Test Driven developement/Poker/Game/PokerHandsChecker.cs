using System;
using System.Linq;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        /// <summary>
        /// Returns true if there are five different cards in the hand. Returns false in all other cases.
        /// </summary>
        /// <param name="hand">Variable of type Hand to be checked</param>
        /// <returns>Boolean</returns>
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            if (!AreAllCardsUnique(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand!");
            }

            if (!this.AreAllCardsOfTheSameSuit(hand))
            {
                return false;
            }

            if (this.AllCardsAreSubsequent(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand!");
            }

            var uniqueCardFacesFromHand = new HashSet<CardFace>();
            foreach (Card card in hand.Cards)
            {
                uniqueCardFacesFromHand.Add(card.Face);
            }

            if (uniqueCardFacesFromHand.Count != 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            var groups = hand.Cards.GroupBy(card => card.Face);

            if (groups.Count() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            if (!IsStraightFlush(hand) && AreAllCardsOfTheSameSuit(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            if (AreAllCardsOfTheSameSuit(hand))
            {
                return false;
            }

            if (AllCardsAreSubsequent(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            if (!this.IsFullHouse(hand))
            {
                var groups = hand.Cards.GroupBy(card => card.Face);

                foreach (var group in groups)
                {
                    if (group.ToArray().Length == 3)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            int numberOfGroupsOfTwo = 0;
            var groups = hand.Cards.GroupBy(card => card.Face);

            foreach (var group in groups)
            {
                if (group.ToArray().Length == 2)
                {
                    numberOfGroupsOfTwo++;
                }
            }

            if (numberOfGroupsOfTwo == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            int numberOfGroupsOfTwo = 0;

            var groups = hand.Cards.GroupBy(x => x.Face);

            foreach (var group in groups)
            {
                var groupToArray = group.ToArray();
                if (groupToArray.Length == 2)
                {
                    numberOfGroupsOfTwo++;
                }
                else if (groupToArray.Length == 3)
                {
                    return false;
                }
            }

            if (numberOfGroupsOfTwo == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool AreAllCardsUnique(IHand hand)
        {
            var cards = hand.Cards;

            for (int left = 0; left < cards.Count - 1; left++)
            {
                var leftCard = cards[left];
                for (int index = left + 1; index < cards.Count; index++)
                {
                    if (leftCard.Face == cards[index].Face && leftCard.Suit == cards[index].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool AreAllCardsOfTheSameSuit(IHand hand)
        {
            var cards = hand.Cards;
            var firstCardSuit = cards[0].Suit;
            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            return true;
        }

        private bool AllCardsAreSubsequent(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => card.Face).ToArray();
            for (int i = 1; i < sortedCards.Length; i++)
            {
                if (sortedCards[i].Face - sortedCards[i - 1].Face != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
