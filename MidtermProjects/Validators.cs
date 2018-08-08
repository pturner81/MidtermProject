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
                return "-1";
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return "-1";
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
                return -1;
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return -1;
            }
        }
        public static int IsQuantityAvailable(int QuantityChosen, List<Products> products, int ChosenItem)
        {//ensures product list has quantity available
            while (QuantityChosen < 0 || QuantityChosen > products[ChosenItem - 1].Quantity)
            {
                Console.WriteLine("Please select an available ammount");
                QuantityChosen = ValidateInt(Console.ReadLine());
            }
            return QuantityChosen;
        }
        public static int IsProductOption(List<Products> list, int ChosenItem)
        {//ensures product selected is an available option
            while (ChosenItem < 1 || ChosenItem > list.Count())
            {
                Console.WriteLine("Please select an available option");
                ChosenItem = ValidateInt(Console.ReadLine());
            }
            return ChosenItem;
        }
        public static string YesOrNo(string UserInput)
        {// loops until user selects available category
            while (UserInput != "y" && UserInput != "yes" && UserInput != "n" && UserInput != "no")
            {
                Console.WriteLine("Please select a valid optin (y/n)");
                UserInput = ValidateString(Console.ReadLine());
            }
            if (UserInput == "yes" || UserInput == "y")
            {
                return "y";
            }
            else
            {
                return "n";
            }
        }
        public static string IsPayOption(string UserInput)
        {//ensures user selects a valide payment method
            while (UserInput != "cash" && UserInput != "check" && UserInput != "credit")
            {
                Console.WriteLine("Please select a valid option (Cash/Check/Credit)");
                UserInput = ValidateString(Console.ReadLine());
            }
            return UserInput;

        }
        public static int IsCartOption(int UserInput, List<Checkout> checkout)
        {//ensures user selects an available object
            while (UserInput < 1 || UserInput > checkout.Count())
            {
                Console.WriteLine("Please select an available option");
                UserInput = ValidateInt(Console.ReadLine());
            }
            return UserInput;
        }
        public static int IsQuantityAvailable2(int QuantityChosen, List<Checkout> checkout, int ChosenItem)
        {//ensures checkout list has quantity available
            while (QuantityChosen < 0 || QuantityChosen > checkout[ChosenItem - 1].Quantity)
            {
                Console.WriteLine("Please select an available amount");
                QuantityChosen = ValidateInt(Console.ReadLine());
            }
            return QuantityChosen;
        }
        public static double ValidateDouble(string UserInput1)
        {//ensures userinput doesn't break code
            try
            {
                double.Parse(UserInput1);
                return (double.Parse(UserInput1));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                return -1;
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
        public static int IsSupplyOption(int UserInput, List<Products> product)
        {//ensures user selects an available object
            while (UserInput < 1 || UserInput > product.Count()+1)
            {
                Console.WriteLine("Please select an available option");
                UserInput = ValidateInt(Console.ReadLine());
            }
            return UserInput;
        }
        public static int IsReSupplyOption(int UserInput, Products p)
        {//ensures user selects an available quantity
            while (p.Quantity + UserInput > 15 || UserInput < 0)
            {
                Console.WriteLine("Please select an available quantity (Max 15 total)");
                UserInput = ValidateInt(Console.ReadLine());
            }
            return UserInput;
        }
        public static int IsUnderMax(int UserInput)
        {//ensures user selects an available quantity
            while (UserInput < 0 || UserInput > 15)
            {
                Console.WriteLine("Please select an available quantity (Max 15)");
                UserInput = ValidateInt(Console.ReadLine());
            }
            return UserInput;
        }
        public static double IsRealInput(double UserInput)
        {//ensures user enters an actual price
            while (UserInput <= 0)
            {
                Console.WriteLine("Please enter an actual price");
                UserInput = ValidateDouble(Console.ReadLine());
            }
            return UserInput;
        }
        public static string IsRealInput(string UserInput)
        {//ensures user enters an actual price
            while (UserInput == "-1")
            {
                Console.WriteLine("Couldn't read that - Please try different wording");
                UserInput = ValidateString(Console.ReadLine());
            }
            return UserInput;
        }
    }
}
