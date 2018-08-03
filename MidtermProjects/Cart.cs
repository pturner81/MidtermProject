using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Cart : Products
    {
        

        //ValidateInt(x);

        //Cart will add objects for each item added to the cart
        
        //Cart will change object proerty "Quantity" from 0 to user number selected

        //Cart will display and ask users if they want change

        //Cart will then print results to a receipt and move to checkout

        //Add three methods to calculate total, tax, and payment due
       
    }
    public static string ValidateString(string UserInput)
    {
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
    public static int ValidateInt(string UserInput1)
    {
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
