using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which category would you like to buy from? (Toys, Books, Games)");
            string cat = Console.ReadLine();
            bool goAgain = true;
           //makes sure the user puts in the right input 
            while (goAgain) 
            {
                if (cat.ToLower() == "toys" || cat.ToLower() == "toy")//shows toys
                {
                    goAgain = false;
                }
                else if (cat.ToLower() == "books" || cat.ToLower() == "book")//shows books
                {
                   goAgain = false;
                }
                else if (cat.ToLower() == "games"|| cat.ToLower() == "game")//shows game
                {
                    goAgain = false;
                }
                else //light validation
                {
                    while (!(Regex.IsMatch(cat, "^[tT][oO][yY][sS]|[tT][oO][yY]|[bB][oO][oO][kK]|[bB][oO][oO][kK][sS]|[bB][oO][oO][kK]|[gG][aA][mM][eE]|[gG][aA][mM][eE][sS]$")))
                    {
                        Console.WriteLine("Enter the right input");
                        cat = Console.ReadLine();
                        goAgain = true;
                    }
                }
}
        }
    }
}
