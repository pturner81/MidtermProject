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
            Instantiate();

            Console.WriteLine("Which category would you like to buy from? (Toys, Books, Games)");
            string cat = Console.ReadLine();
            bool goAgain = true;
            //makes sure the user puts in the right input
            //list cart imported from the cart class
            //printagain = 0 
            while (goAgain)
            {
                //if printagain = 1 cw("Pick another category") takes in cat value and runs through again
                if (cat.ToLower() == "toys" || cat.ToLower() == "toy")//shows toys
                {
                    //show toys, ask if they would like to add any to cart 
                    //while addtocart == true
                    //ask if they would like to add anything else to cart 
                    //outside the loop it asks if they want to go to another category
                    //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
                    goAgain = false;// if they are done adding items to the cart and would like to go to check out
                }
                else if (cat.ToLower() == "books" || cat.ToLower() == "book")//shows books
                {


                    //show books, ask if they would like to add any to cart 
                    //while addtocart == true
                    //ask if they would like to add anything else to cart 
                    //outside the loop it asks if they want to go to another category
                    //if yes then  printagain = 1 and goAgain = true the program ask for user to input another catgory
                    goAgain = false;// if they are done adding items to the cart and would like to go to check out
                }
                else if (cat.ToLower() == "games" || cat.ToLower() == "game")//shows game
                {

                    //show games, ask if they would like to add any to cart 
                    //while addtocart == true
                    //ask if they would like to add anything else to cart 
                    //outside the loop it asks if they want to go to another category
                    //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
                    goAgain = false;// if they are done adding items to the cart and would like to go to check out
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
            //checkout code 
        }

        private static void Instantiate()
        {
            Book prod1, prod2, prod3;

            prod1 = new Book("Venom meets Carnage", "volume 1 issue 12 47 pages.", "Venom\'s Revenge", "234535", 5.99);
            prod2 = new Book("The beginning of Wolverine", "Volume 1 issue 1", "Wolverine Genesis", "464848293", 6.99);
            prod3 = new Book("Tacos and Mercs", " Volume 3 issue 24", "Deadpool lives", "2737483746", 11.99);

            List<Book> products = new List<Book>() { prod1, prod2, prod3 };
        }

        public void PrintList(List<Book> products)
        {
            foreach (Book prod in products)
            {
                PrintList(products);
                Console.WriteLine();
            }
        }
    }
}
