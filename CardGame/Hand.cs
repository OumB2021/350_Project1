using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Hand
    {
        private List<Card> cardList = new List<Card>();

        // constructor
        public Hand()
        {

        }

        // properties
        public bool Empty
        {
            get { return cardList.Count == 0; }
        }

        public int Count
        {
            get { return cardList.Count; }
        }

        // methods
        public void AddCard (Card c)
        {
            cardList.Add(c);
        }

        public Card GetCard(int index)
        {
            if (index < cardList.Count && index >= 0)
            {
                return cardList[index];
            }
                return null;
        }

        public void RemoveCard(int index)
        {
            if (index < cardList.Count && index >= 0)
            {
                cardList.RemoveAt(index);
            }

        }

        public bool isEmpty()
        {
            return cardList.Count == 0;
        }
    }
}
