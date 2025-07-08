using System.Collections;

namespace desing_patterns_c_sharp.Behavioral.Iterator
{


    public class Card
    {
        public string Name { get; }
        public int Value { get; }

        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"Card: {Name}, Value: {Value}";
        }
    }

    public class CardCollection : IEnumerable<Card>
    {
        private List<Card> cards = new List<Card>();

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            foreach (var card in cards)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Card> GetCard()
        {
            foreach (var card in cards)
            {
                yield return card;
            }
        }
    }

    public static class Iterator_3
    {
        public static void Main()
        {
            var deck = new CardCollection();
            deck.AddCard(new Card("Ace of Hearts", 1));
            deck.AddCard(new Card("King of Hearts", 13));
            deck.AddCard(new Card("Queen of Hearts", 12));
            deck.AddCard(new Card("Jack of Hearts", 11));

            Console.WriteLine("Traversing the card collection:");
            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
        }
    }


   
}
