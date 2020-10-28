using System.Collections.Generic;

namespace Blackjack.Models
{
    public class Suites
    {
        public const string Diamonds = "Diamonds";
        public const string Hearts = "Hearts";
        public const string Spades = "Spades";
        public const string Clubs = "Clubs";

        public static List<string> GetSuites()
        {
            return new List<string>()
            {
                Diamonds,
                Hearts,
                Spades,
                Clubs
            };
        }
    }
}