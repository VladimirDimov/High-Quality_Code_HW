using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var cardReport = this.Face + " of " + this.Suit.ToString().ToLower();

            return cardReport;
        }

        public static bool operator ==(Card a, Card b)
        {
            if (a.Face == b.Face && a.Suit == b.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Card a, Card b)
        {
            return !(a == b);
        }
    }
}
