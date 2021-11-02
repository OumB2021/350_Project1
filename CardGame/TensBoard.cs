using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class TensBoard : Board
    {
        // This method checks if the cards Ten, Jack, Queen and King
        // exists in the list at the same time.
        public bool ValidateJQKT()
        {
            // boolean variables
            bool isKing, isQueen, isJack, isTen;
            isKing = isQueen = isJack = isTen = false;

            for (int i = 0; i < List.Count; i++)
            {
                // when King is found
                if (List[i].Rank == "King")
                    isKing = true;

                // when Queen is found
                if (List[i].Rank == "Queen")
                    isQueen = true;

                // when Jack is found
                if (List[i].Rank == "Jack")
                    isJack = true;

                // when Ten is found
                if (List[i].Rank == "Ten")
                    isTen = true;
            }

            if (isKing && isQueen && isJack && isTen)
                Console.WriteLine("\nThere's a combination of King, Queen, Jack and Ten in the list");

            return isKing && isQueen && isJack && isTen;
        }

        // Displays the rules of the game at the beginning of the game.
        public void Rules()
        {
            Console.WriteLine("\nThese are the rules of the TensGame :\n" +
                              "1. The game uses a list of 13 cards\n" +
                              "2. Find a pair of cards whose values add to 10\n" +
                              "3. If the player finds a pair, his score is incremented by 1\n" +
                              "4. The pairs are selected and removed from the game\n" +
                              "5. The card King, Queen, Jack and Ten are also removed from the game\n" +
                              "6. If no more pair of cards can be found, player loses the game\n" +
                              "7. Player would win the game if he doesn't have any more cards in the list\n");                     
        }

        // This method checks if the combination of the two cards
        // matches our game requirement
        public override bool isValidSelection(int card1, int card2)
        {
            int value = List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue();
            Console.WriteLine("\nThe selected cards total value is : " + value + "\n");

            if (value == 10)
            {
                score++;
                return true;
            }

            else
                return false;
        }

        // This method removes the cards King, Queen, Jack and Ten
        public void removeUndesiredCards(int card1, int card2, int card3, int card4)
        {
            int[] arr = new int[] { card1, card2, card3, card4};
            Array.Sort(arr);

            List.RemoveAt(arr[3] - 1);
            List.RemoveAt(arr[2] - 1);
            List.RemoveAt(arr[1] - 1);
            List.RemoveAt(arr[0] - 1);

            if (deck.Count == 1)
                List.Add(deck.TakeTopCard());

            else if (deck.Count == 2)
            {
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
            }

            else if (deck.Count == 3)
            {
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
            }

            else
            {
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
                List.Add(deck.TakeTopCard());
            }
        }

        // This method checks if there's more combination of cards 
        // in the list
        public override bool PairExists()
        {
            int cardValue;
            for (int i = 0; i < List.Count; i++)
            {
                for (int j = i + 1; j < List.Count; j++)
                {
                    cardValue = 0;
                    cardValue += List[i].getCardValue();
                    cardValue += List[j].getCardValue();

                    // if two cards with total equals to 10 is found.
                    if (cardValue == 10)
                        return true;
                }
            }

            return false;
        }

    }
}
