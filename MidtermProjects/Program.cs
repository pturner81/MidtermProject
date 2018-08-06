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

            //    Console.WriteLine("Which category would you like to buy from? (Toys, Books, Games)");
            //    string cat = ValidateString(Console.ReadLine());
            //    bool goAgain = true;
            //    //makes sure the use r puts in the right input
            //    //list cart imported from the cart class
            //    //printagain = 0 
            //    while (goAgain)
            //    {
            //        //if printagain = 1 cw("Pick another category") takes in cat value and runs through again
            //        if (cat == "toys" || cat == "toy")//shows toys
            //        {
            //            //show toys, ask if they would like to add any to cart 
            //            //while addtocart == true
            //            //ask if they would like to add anything else to cart 
            //            //outside the loop it asks if they want to go to another category
            //            //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
            //            goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //        }
            //        else if (cat == "books" || cat == "book")//shows books
            //        {


            //            //show books, ask if they would like to add any to cart 
            //            //while addtocart == true
            //            //ask if they would like to add anything else to cart 
            //            //outside the loop it asks if they want to go to another category
            //            //if yes then  printagain = 1 and goAgain = true the program ask for user to input another catgory
            //            goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //        }
            //        else if (cat == "games" || cat == "game")//shows game
            //        {

            //            //show games, ask if they would like to add any to cart 
            //            //while addtocart == true
            //            //ask if they would like to add anything else to cart 
            //            //outside the loop it asks if they want to go to another category
            //            //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
            //            goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //        }
            //        else //light validation
            //        {
            //            while (!(Regex.IsMatch(cat, "^[tT][oO][yY][sS]|[tT][oO][yY]|[bB][oO][oO][kK]|[bB][oO][oO][kK][sS]|[bB][oO][oO][kK]|[gG][aA][mM][eE]|[gG][aA][mM][eE][sS]$")))
            //            {
            //                Console.WriteLine("Enter the right input");
            //                cat = Console.ReadLine();
            //                goAgain = true;
            //            }
            //        }
            //    }
            //    //checkout code 
            // print list of items they wanted to buy
            // ask if they are paying with card cash or check
            // if (card)
            //{
            //   ask for and validate card number (Regex.IsMatch(^\d{16}$))
            //   ask for zip code (Regex.IsMatch(^\d{5}$))
            //   ask for cvv (Regex.IsMatch(^\d{3}$))
            //   store info
            //}
            //else if(check)
            //{
            //   ask for and validate account number (Regex.IsMatch(^\d{10}$))
            //   ask for and validate routing number (Regex.IsMatch(^\d{9}$))
            //   ask for and validate check number (Regex.IsMatch(^\d{3}|\d{4}$))
            //   store info
            //}
            // else if (cash){
            //   ask for amount
            //   subtract the cost of the product with the amount paid and print change
            //   store info
            // }
            // else{
            //  prompt them to enter the right information or run validation method before hand
            //}
            // print receipt with payment info
            //public void PrintList(List<Book> products)
            //{
            //    foreach (Book prod in products)
            //    {
            //        PrintList(products);
            //        Console.WriteLine();
            //    }
            //}
            //public static string ValidateString(string UserInput)
            //{
            //    try
            //    {
            //        UserInput = UserInput.ToLower();
            //        return (UserInput);
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine(e.Message);
            //        return "0";
            //    }
            //    catch (Exception f)
            //    {
            //        Console.WriteLine(f.Message);
            //        return "0";
            //    }
        }
    }
}
