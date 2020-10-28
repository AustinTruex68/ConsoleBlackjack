using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public static Deck Generate()
        {
            var result = new Deck(){Cards = new List<Card>()};
            foreach (var suite in Suites.GetSuites())
                for (var i = 1; i <= 13; i++)
                {
                    int? altNumber = null;
                    var num = i;
                    if (i >= 10)
                        num = 10;
                    
                    var val = i.ToString();
                    if (i == 1)
                    {
                        val = "Ace";
                        altNumber = 11;
                    }

                    if (i == 11)
                        val = "Jack";
                    if (i == 12)
                        val = "Queen";
                    if (i == 13)
                        val = "King";
                    
                    result.Cards.Add(new Card()
                    {
                        Number = num,
                        Value = val,
                        Suite = suite,
                        AltNumber = altNumber
                    });
                }

            return result.Shuffle();
        }

        public Card Draw()
        {
            if (Cards.Count < 1)
                Cards = Generate().Cards;
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        private Deck Shuffle()
        {
            Console.WriteLine("\nShuffling deck...");
            Cards = Cards.OrderBy(a => Guid.NewGuid()).ToList();
            return this;
        }
    }
}