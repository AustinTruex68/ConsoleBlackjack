namespace Blackjack.Models
{
    public class Card
    {
        public int Number { get; set; }
        public int? AltNumber { get; set; }
        public string Value { get; set; }
        public string Suite { get; set; }
    }
}