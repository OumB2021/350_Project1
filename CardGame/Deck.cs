using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        // Constructor
        public Deck()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }

        // Properties
        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        public int Count
        {
            get { return cards.Count; }
        }

        // Methods

        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count-1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }

            else
                return null;   
        }

        public void Shuffle()
        {
            Card temp;
            Random rand = new Random();
            int number;

            for (int i = cards.Count - 1; i > 1; i--)
            {
                number = rand.Next(cards.Count - 1) + 1;
                temp = cards[i];
                cards[i] = cards[number];
                cards[number] = temp;
            }
        }

        public void Cut (int position)
        {
            Card[] cutCards = new Card[position];

            for (int i = 0; i < position; i++)
            {
                cutCards[i] = cards[0];
                cards.RemoveAt(0);
            }

            cards.AddRange(cutCards);
        }

        public void Print(Deck d)
        {
            if (Empty)
                Console.WriteLine("You don't have any cards in the deck");
            else
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    Card c = d.TakeTopCard();
                    Console.WriteLine("Rank : " + c.Rank + ", Suit is : " + c.Suit);
                }
            }
        }
        
    }
}
