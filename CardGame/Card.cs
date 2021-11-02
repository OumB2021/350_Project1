using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Card
    {   
        // variables
        private string rank;
        private string suit;
        private bool faceUp;

        // Constructor
        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
            faceUp = false;    
        }
        
        // Properties
        public string Rank
        {
            get { return rank; }
        }

        public string Suit
        {
            get { return suit; }
        }
        public bool FaceUp
        {
            get { return faceUp; }
        }

        // Method
        public void FlipOver()
        {
            faceUp = !faceUp;
        }

        public int getCardValue()
        {
            return (int)System.Enum.Parse(typeof(Rank), Rank) + 1;
        }
    }
}
