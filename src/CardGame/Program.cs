using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BusinessLogic obj = new BusinessLogic();
                obj.runGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn Error occurred while running the Game. The error messge is - " + ex.Message + "\n");
            }
        }
    }
}
