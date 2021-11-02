using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class ThirteensBoard : Board
    {
        // This method checks if the King card exists in the list.
        public bool ValidateK()
        {
            bool isKing;
            isKing = false;

            for (int i = 0; i < List.Count && isKing == false; i++)
            {
                // when King is found
                if (List[i].Rank == "King")
                    isKing = true;
            }

            if (isKing == true)
                Console.WriteLine("\nThere's a King card in the list");

            return isKing;
        }

        // Displays the rules of the game at the beginning of the game.
        public void Rules()
        {
            Console.WriteLine("\nThese are the rules of the ThirteensGame :\n" +
                              "1. The game uses a list of 10 cards\n" +
                              "2. Find a pair of cards whose values add to 13\n" +
                              "3. If the player finds a pair, his score is incremented by 1\n" +
                              "4. The pairs are selected and removed from the game\n" +
                              "5. The card King is also removed from the game\n" +
                              "6. If no more pair of cards can be found, player loses the game\n" +
                              "7. Player wins the game if he doesn't have any more cards in the list\n");
        }

        // This method checks if the combination of the two cards
        // matches our game requirement
        public override bool isValidSelection(int card1, int card2)
        {
            Console.WriteLine("The selected cards total value is : " +
            (List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue()) +"\n");

            if ((List[card1 - 1].getCardValue() + List[card2 - 1].getCardValue()) == 13)
            {
                score++;
                return true;
            }

            else
                return false;
        }

        // This method removes the King card from the list
        public void removeUndesiredCards(int card)
        {
            List.RemoveAt(card - 1);

            if(!deck.Empty)
            List.Add(deck.TakeTopCard());    
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
                    if (cardValue == 13)
                        return true;
                }
            }

            return false;
        }
    }
}
