using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        List<Card> List = new List<Card>();
        Deck deck = new Deck();

        [TestMethod()]
        public void Distribute_cards_to_user_test()
        {
            deck.Shuffle();
            List.Add(deck.TakeTopCard());
            for (int i = 1; i < deck.Count; i++)
            {
                List.Add(deck.TakeTopCard());
                if (List[i-1].Rank == List[i].Rank && List[i-1].Suit == List[i].Suit)
                    Assert.Fail();
            }

            Assert.AreEqual(deck.Count, List.Count);
        }

        [TestMethod()]
        public void Pair_of_cards_exists_test()
        {
            deck.Shuffle();
            int valueOfCards = 0, matchingValue = 10;

            for (int i = 0; i < deck.Count; i++)
              List.Add(deck.TakeTopCard());

            for (int i = 0; i < deck.Count; i++)
            {
                for (int j = i + 1; j < deck.Count; j++)
                {
                    valueOfCards += List[i].getCardValue();
                    valueOfCards += List[j].getCardValue();

                    if (valueOfCards == matchingValue)
                        Assert.AreEqual(10, valueOfCards);
                }
            }
        }

        [TestMethod()]
        public void Gets_two_cards_returns_value_test()
        {
            int value;

            List.Add(new Card("Six", "Spades"));
            List.Add(new Card("Five", "Hearts"));
            List.Add(new Card("Ace", "Diamonds"));
            List.Add(new Card("Four", "Clubs"));

            value = List[0].getCardValue() + List[3].getCardValue();

            Assert.AreEqual(10, value);
        }

        [TestMethod()]
        public void Remove_two_cards_from_List_test()
        {
            bool doesExist = false;

            // creating 5 cards
            Card card1 = new Card("Six", "Spades");
            Card card2 = new Card("Five", "Hearts");
            Card card3 = new Card("Ace", "Diamonds");
            Card card4 = new Card("Four", "Clubs");
            Card card5 = new Card("Four", "Clubs");

            //Add them to the list
            List.Add(card1);
            List.Add(card2);
            List.Add(card3);
            List.Add(card4);
            List.Add(card5);

            // removing card1 and card4
            List.RemoveAt(0);
            List.RemoveAt(2);

            for (int i = 0; i<List.Count; i++)
            {
                if (List[i].Rank == card1.Rank && List[i].Suit == card1.Suit ||
                    List[i].Rank == card4.Rank && List[i].Suit == card4.Suit)
                    doesExist = true;
            }

            if (!doesExist)
                Assert.AreEqual(3, List.Count);
        }
    }
}