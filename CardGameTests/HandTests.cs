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

        [TestMethod()]
        public void Get_Card_Test()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card("Ace", "Spades"));

            Card card = hand.GetCard(0);

            Assert.IsTrue(card.Rank == "Ace" && card.Suit == "Spades");
        }

        [TestMethod()]
        public bool EmptyTest()
        {
            Hand hand = new Hand();
            Assert.IsTrue(hand.Count == 0);
        }

        [TestMethod()]
        public Hand_constructor_Test()
        {
            Hand hand = new Hand();
            Assert.IsTrue(hand.Count == 0);
        }

        [TestMethod()]
        public int get_Count_test()
        {
            Hand hand = new Hand();
            Assert.IsTrue(hand.Count == 0);
        }

    }
}