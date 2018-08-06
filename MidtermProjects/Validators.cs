using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Validators
    {
        public static string ValidateString(string UserInput)
        { //ensures userinput doesnt break code
            try
            {
                UserInput = UserInput.ToLower();
                return (UserInput);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return "0";
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return "0";
            }
        }
        public static string IsOption(string UserInput)
        {// loops until user selects available category
            while (UserInput != "toys" && UserInput != "toy" && UserInput != "books" && UserInput != "book" && UserInput != "games" && UserInput != "game")
            {
                Console.WriteLine("Please select a valid category (Toys/Books/Games)");
                UserInput = ValidateString(Console.ReadLine());
            }
            if (UserInput == "toys" || UserInput == "toy")
            {
                return "toys";
            }
            else if (UserInput == "books" || UserInput == "book")
            {
                return "books";
            }
            else
            {
                return "games";
            }
        }
        public static int ValidateInt(string UserInput1)
        {//ensures userinput doesn't break code
            try
            {
                int.Parse(UserInput1);
                return (int.Parse(UserInput1));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return 0;
            }
        }


    }
}
