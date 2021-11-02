using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Tests
{
    [TestClass()]
    public class HandTests
    {
        Hand hand = new Hand();

        [TestMethod()]
        public void HandTest()
        {
            Assert.IsTrue(hand.Empty);
        }

        [TestMethod()]
        public void AddCardTest()
        {
          
            Card newCard = new Card("Ace", "Spades");
            Card anotherCard = new Card("Queen", "Hearts");

            hand.AddCard(newCard);
            hand.AddCard(anotherCard);

            Assert.IsTrue(hand.Count == 2);
        }

        [TestMethod()]
        public void GetCardTest()
        {
            hand.AddCard(new Card("Ace", "Spades"));

            Card card = hand.GetCard(0);

            Assert.IsTrue(card.Rank == "Ace" && card.Suit == "Spades");
        }

        [TestMethod()]
        public void RemoveCardTest()
        {
            Card card1 = new Card("Ace", "Spades");
            Card card2 = new Card("Queen", "Hearts");
            Card card3 = new Card("Jack", "Clubs");


            hand.AddCard(card1);
            hand.AddCard(card2);
            hand.AddCard(card3);

            hand.RemoveCard(0);
            hand.RemoveCard(0);
            hand.RemoveCard(0);
            hand.RemoveCard(0); // error exception.

            Assert.IsTrue(hand.Empty);
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            Hand hand = new Hand();

            Assert.IsTrue(hand.Empty);
        }

        [TestMethod()]

        public void Count_Test()
        {
            hand.AddCard(new Card("Three", "Hearts"));

            int count = 1;

            Assert.AreEqual(count, hand.Count);
        }
    }
}