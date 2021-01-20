using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class BusinessObject
    {
        internal Stack<string> cardDeck = new Stack<string>();
        internal string[] suits = { "Clubs", "Hearts", "Spades", "Diamonds" };
        internal string[] cardPerSuit = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
    }
}
