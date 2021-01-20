using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class BusinessLogic
    {
        BusinessObject obj;
        internal BusinessLogic()
        {
            InitializeDeck();
        }

        internal void runGame()
        {
            try
            {
                string message = "";
                int no = 0;

                // Fetch user input...
                Console.WriteLine("Please select any of the option below\n" +
               "1. Play a card\n" +
               "2. Shuffle the deck\n" +
               "3. Restart the game\n");

                if (ValidateUserInput(Console.ReadLine(), out message, out no))
                {
                    if (no == 1)
                    {
                        PlayACard();
                    }
                    else
                    if (no == 2)
                    {
                        if (obj.cardDeck.Count > 0)
                        {
                            ShuffleDeck();
                            Console.WriteLine("Deck shuffled successfully\nCurrent card count - " + obj.cardDeck.Count + "\n");
                        }
                        else
                            Console.WriteLine("You have drawn all the cards. Please restart the game in order to shuffle the cards.\n");
                    }
                    else
                    {
                        Restart();
                    }
                }
                else
                {
                    Console.WriteLine(message);
                }

                runGame();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeDeck()
        {
            try
            {
                obj = new BusinessObject();

                foreach (var sut in obj.suits)
                {
                    foreach (var crd in obj.cardPerSuit)
                    {
                        obj.cardDeck.Push(crd + " of " + sut);
                    }
                }
                ShuffleDeck();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PlayACard()
        {
            try
            {
                if (obj.cardDeck.Count > 0)
                    Console.WriteLine("Card drawn successfully.\nThe Card drawn by you is - " + obj.cardDeck.Pop() + "\nCurrent card count - " + obj.cardDeck.Count + "\n");
                else
                    Console.WriteLine("You have drawn all the cards. Please restart the game.\n");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShuffleDeck()
        {
            try
            {
                string[] shuffledCards = new string[obj.cardDeck.Count];
                int count = 0;
                Random random = new Random();

                foreach (var item in obj.cardDeck)
                    shuffledCards[count++] = item;

                for (int i = shuffledCards.Length - 1; i > 0; i--)
                {
                    int randomIndex = random.Next(0, i + 1);

                    string temp = shuffledCards[i];
                    shuffledCards[i] = shuffledCards[randomIndex];
                    shuffledCards[randomIndex] = temp;
                }

                while (obj.cardDeck.Count > 0)
                    obj.cardDeck.Pop();

                for (int i = 0; i < shuffledCards.Length; i++)
                    obj.cardDeck.Push(shuffledCards[i]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Restart()
        {
            try
            {
                // Call initialize method to re-initialize the stack...
                InitializeDeck();
                Console.WriteLine("Game restarted successfully\nCurrent card count - " + obj.cardDeck.Count + "\n");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Validate if user input is valid...
        private bool ValidateUserInput(string input, out string message, out int no)
        {
            Console.Clear();

            try
            {
                // check if user inout is numeric or not...
                bool isNumeric = int.TryParse(input, out no);

                if (isNumeric)
                {
                    if (no >= 1 && no <= 3)
                    {
                        message = "";
                        return true;
                    }
                    else
                    {
                        message = "Please enter a number between 1, 2, 3\n";
                        return false;
                    }
                }
                else
                {
                    message = "Please enter a number between 1, 2, 3\n";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
