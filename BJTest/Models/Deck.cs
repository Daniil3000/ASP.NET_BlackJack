using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJTest
{
    public class Deck
    {

        public static Stack<Card> CreateDeck()
        {
            // creating a stack to store our cards
            Stack<Card> CardDeck = new Stack<Card>();

            for (int i = 0; i < 13; i++)
            {
                for(int j = 0; j <4; j++)
                {
                    Card card = new Card();

                    // getting values for ach card
                    if (i <= 8)
                    {
                        // values for cards 2-10
                        card.IntegerValue = i + 2;
                        card.StringValue = (i+2).ToString();

                    }
                    else
                    {
                        // values for Jack, Queen, King and Ace
                        switch (i)
                        {
                            case 9:
                                card.IntegerValue = 10;
                                card.StringValue = "J";
                                break;
                            case 10:
                                card.IntegerValue = 10;
                                card.StringValue = "Q";
                                break;
                            case 11:
                                card.IntegerValue = 10;
                                card.StringValue = "K";
                                break;
                            case 12:
                                card.IntegerValue = 11;
                                card.StringValue = "A";
                                break;
                        }
                    }

                    // generating a suit for each card
                    switch (j)
                    {
                        case 0:
                            // Clubs
                            card.Suit = "C";
                            break;
                        case 1:
                            // Diamonds
                            card.Suit = "D";
                            break;
                        case 2:
                            // Hearts
                            card.Suit = "H";
                            break;
                        case 3:
                            // Spades
                            card.Suit = "S";
                            break;
                    }

                    // getting an image for each card
                    card.ImageSrc = $"Images/Cards/{card.StringValue}{card.Suit}.png";

                    // adding a card to the deck
                    CardDeck.Push(card);
                }
            }

            return CardDeck;
        }

        public static Stack<Card> ShuffleDeck(Stack<Card> cardDeck)
        {
            // shuffling deck
            var cardList = cardDeck.ToArray();

            // clear original deck
            cardDeck.Clear();
            
            // shuffling cards inside list
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int firstCard = rnd.Next(0, 52);
                int secondCard = rnd.Next(0, 52);
                if (firstCard != secondCard)
                {
                    var tempCard = cardList[firstCard];
                    cardList[firstCard] = cardList[secondCard];
                    cardList[secondCard] = tempCard;
                }
            }

            // repopulate original deck with shuffled cards
            foreach (var card in cardList)
            {
                cardDeck.Push(card);
            }

            // return shuffled deck
            return cardDeck;
        }
    }
}