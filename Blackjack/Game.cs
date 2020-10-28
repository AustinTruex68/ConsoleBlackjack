using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blackjack.Models;

namespace Blackjack
{
    public static class Game
    {
        private static Deck _deck;

        static Game()
        {
            _deck = Deck.Generate();
        }

        public static void StartGame()
        {
            Console.WriteLine("Started!");
        }

        public static List<Card> GetUserHand()
        {
            var c1 = _deck.Draw();
            var c2 = _deck.Draw();

            return new List<Card>(){c1,c2};
        }


        public static List<Card> GetDealerHand()
        {
            var c1 = _deck.Draw();
            return new List<Card>(){c1};
        }

        public static List<Card> Hit(List<Card> hand)
        {
            hand.Add(_deck.Draw());
            return hand;
        }
    }
}