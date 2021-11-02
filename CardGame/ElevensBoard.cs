using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class ElevensBoard : Board
    {
        // This method checks if the cards Jack, Queen and King
        // exists in the list at the same time.
        public bool ValidateJQK()
        {
            // boolean variables
            bool isKing, isQueen, isJack;
            isKing = isQueen = isJack = false;

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
            }

            if (isKing && isQueen && isJack)
                Console.WriteLine("\nThere's a king card in the list");

            return isKing && isQueen && isJack;
        }


        // Displays the rules of the game at the beginning of the game.
        public void Rules()
        {
            Console.WriteLine("\nThese are the rules of the ElevensGame :\n" +
                              "1. The game uses a list of 9 cards\n" +
                              "2. Find a pair of cards whose values add to 11\n" +
                              "3. If the player finds a pair, his score is incremented by 1\n" +
                              "4. The pairs are selected and removed from the game\n" +
                              "5. The card King, Queen and Jack are also removed from the game\n" +
                              "6. If no more pair of cards can be found, player loses the game\n" +
                              "7. Player wins the game if he doesn't have any more cards in the list\n");
        }

        // This method checks if the combination of the two cards
        // matches our game requirement
        public override bool isValidSelection(int card1, int card2)
        {
            Console.WriteLine("The selected cards total value is : " +
            (List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue()) + "\n");

            if ((List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue()) == 11)
            {
                score++;
                return true;
            }

            else
                return false;
        }

        // This method removes the cards King, Queen and Jack
        public void removeUndesiredCards(int card1, int card2, int card3)
        {
            int[] arr = new int[] { card1, card2, card3 };
            Array.Sort(arr);

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

            else
            {
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
                    if (cardValue == 11)
                        return true;
                }
            }

            return false;
        }

    }
}
