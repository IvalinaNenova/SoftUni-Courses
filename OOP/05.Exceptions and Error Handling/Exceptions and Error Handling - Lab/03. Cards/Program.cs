using System;
using System.Collections.Generic;

namespace _03._Cards
{
    public class Card
    {
        private Dictionary<string, char> cardSuits = new Dictionary<string, char>
        {
            {"H", '\u2665'},
            {"C", '\u2663'},
            {"D", '\u2666'},
            {"S", '\u2660'},
        };
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{cardSuits[Suit]}]";
        }
    }

    public enum SuitValue
    {
        H, C, D, S
    }


    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new List<Card>();
            string[] cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cardInfo in cards)
            {
                Card card = null;

                try
                {
                    string[] cardData = cardInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    card = CreateCard(cardData[0], cardData[1]);
                    deck.Add(card);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

            Console.WriteLine(string.Join(' ', deck));

        }

        public static Card CreateCard(string face, string suit)
        {
            var faceValues = new List<string>
                {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

            if (!faceValues.Contains(face))
            {
                throw new ArgumentException("Invalid card!");
            }

            if (!Enum.IsDefined(typeof(SuitValue), suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            return new Card(face, suit);
        }
    }
}
