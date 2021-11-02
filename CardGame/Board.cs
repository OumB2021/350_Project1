using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    abstract class Board
    {
        // Member variables
        protected List<Card> List;
        protected Deck deck;
        static protected int score;

        // Constructor
        public Board()
        {
            List = new List<Card>();
            deck = new Deck();
            deck.Shuffle();
            score = 0;
        }

        // Select the game to play
        public void Play(int gameSelection)
        {
            // TensBoard game case
            if (gameSelection == 1)        
            {
                for (int i = 0; i < 13; i++)
                    List.Add(deck.TakeTopCard());
            }

            // ElevensBoard game case
            if (gameSelection == 2)
            {
                for (int i = 0; i < 9; i++)
                    List.Add(deck.TakeTopCard());
                
            }

            // ThirteensBoard game case
            if (gameSelection == 3)
            {
                for (int i = 0; i < 10; i++)
                    List.Add(deck.TakeTopCard());
            }
        }

        // This function prints a list of card
        // their rank and Suit and the remaining cards
        // in the deck
        public void PrintList()
        {
            Console.Write("\n");

            for (int i = 0; i<List.Count; i++)
            {
                Console.WriteLine("Card #" + (i + 1) + " Rank : "
                + List[i].Rank + ", Suit : " + List[i].Suit);
            }
            
            Console.WriteLine("\nYou have " + CardsRemaining + " cards in the Deck");
            Console.WriteLine("Your score is : " + score);
        }

        public virtual void resetGame()
        {
            Console.WriteLine("\nThe game has been reset.\nYour new list of card is : \n");

            int saveCount = List.Count;

            score = 0; // set score to 0

            List.Clear(); // empty the list
            deck = new Deck(); // create a new deck 
            deck.Shuffle(); // shuffle the deck

            // Add new cards to the list
            for (int i = 0; i < saveCount; i++)
                List.Add(deck.TakeTopCard()); 
        }

        // This methode validates a given card
        // to make sure the right card is selected
        public bool validateCard(int card, string rank)
        {
            if (List[card - 1].Rank == rank)
                return true;

            return false;
        }

        // Property to get the score of the user
        public int Score
        {
            get { return score; }
        }

        // Virtual method to check if the combination of the two cards
        // matches our game requirement
        public virtual bool isValidSelection(int card1, int card2)
        {
            Console.WriteLine("The selected cards total value is : " +
            List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue());

            if ((List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue()) == 10)
            {
                score++; // increment score if combination is valid
                return true;            
            }
                
            else
                return false;
        }

        public virtual bool PairExists()
        {
            return true;
        }

        public void SelectTwoCards(ref int input1, ref int input2)
        {
            // Get one card from user and validate the input.
            do
            {
                Console.Write("\nselect card #1 : ");
                input1 = Convert.ToInt32(Console.ReadLine());
            } while (input1 < 1 || input1 >= List.Count + 1);

            // Select another card from the user and validate the input.
            Console.Write("select card #2 : ");
            input2 = Convert.ToInt32(Console.ReadLine());

            while (input2 < 1 || input2 >= List.Count + 1 || input2 == input1)
            {
                // In case card#1 and card#2 are the same.
                if (input2 == input1)
                {
                    Console.Write("You have already selected this card. Please try again: ");
                    input2 = Convert.ToInt32(Console.ReadLine());
                }

                else
                {
                    Console.Write("Please enter a card from 1 to " + (List.Count ) + " but not the card #" + input1 + ":");
                    input2 = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        // Replaces the cards after the requirement is met
        public void replaceCards(int card1, int card2)
        {
            int[] arr = new int[] {card1, card2};
            Array.Sort(arr);

            // Remove the cards
            List.RemoveAt(arr[1] - 1);
            List.RemoveAt(arr[0] - 1);

            // check if the deck has at least two cards
            if (deck.Count >= 2)
            {
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
            }

            // In case deck has only one card left
            else
                List.Add(deck.TakeTopCard());
        }

        // Bool function that checks if user has won the game
        public bool hasWon()
        {
            return List.Count == 0 && deck.Empty;
        }

        // property that returns the card remaining in the deck
        public int CardsRemaining
        {
            get { return deck.Count; }
        }
    }
}
