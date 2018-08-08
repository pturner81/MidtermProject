using System;
using System.Collections.Generic;
using System.IO;
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
            List<Products> products = new List<Products>();
            List<Cart> cart = new List<Cart>();

            ReadTxtFileInstantiateList(products, cart);

            ReSupplyLoop(products, cart);

            string ReRunProgram = "y";
            while (ReRunProgram == "y")
            {
                WelcomeMessage();

                string Continue = "y";
                Continue = ShoppingLoop(products, cart, Continue);

                List<Checkout> checkout = InstantiateCheckout(cart);

                PrintCheckout(checkout);

                Console.WriteLine("Would you like to remove any items from your cart? (y/n)-- (Type 'n' to move to checkout)");
                string remove = Validators.ValidateString(Console.ReadLine());
                remove = Validators.YesOrNo(remove);

                remove = CartLoop(checkout, remove);


                double SubTotal, Tax, Total;
                Totals(checkout, out SubTotal, out Tax, out Total);

                PrintFinalCheckout(checkout, SubTotal, Tax, Total);

                Checkout(Total);

                PrintReceipt(checkout, SubTotal, Tax, Total);

                Console.Clear();
                PrintFinalCheckout(checkout, SubTotal, Tax, Total);

                EndProgram();

                Console.WriteLine();

                ClearCart(cart, checkout);

                ReRunProgram = ShopAgain();
            }
            Console.WriteLine("Thank you for shopping with us!");
            Console.WriteLine("Press any key to exit");
        }

        private static void ReadTxtFileInstantiateList(List<Products> products, List<Cart> cart)
        {
            StreamReader reader = new StreamReader("../../DataInput.txt");

            List<string> stringList = new List<string>();
            string fileData = "";
            string nextLine = reader.ReadLine();
            while (nextLine != null)
            {
                fileData += nextLine + "\n";
                stringList.Add(nextLine);
                nextLine = reader.ReadLine();
            }
            foreach (string s in stringList)
            {
                string[] info = s.Split(',');

                Products temp = new Products(info[0], info[1], info[2], info[3], double.Parse(info[4]), int.Parse(info[5]));
                products.Add(temp);
                Cart temp1 = new Cart(info[0], double.Parse(info[4]), 0);
                cart.Add(temp1);
            }
            reader.Close();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to GC Comics!");
            Console.WriteLine("Press any key to view inventory");
            Console.ReadKey();
        }

        private static string ShoppingLoop(List<Products> products, List<Cart> cart, string Continue)
        {//allows user to select item and quantity to purchase and loops until user requst
            while (Continue == "y")
            {
                PrintInfo(products);

                Console.WriteLine($"What item would you like to purchase? (1-{products.Count()})");
                int ChosenItem = Validators.ValidateInt(Console.ReadLine());
                ChosenItem = Validators.IsProductOption(products, ChosenItem);

                PrintHeadersOne();
                products[ChosenItem - 1].PrintInfo1();

                Console.WriteLine();
                Console.WriteLine($"How many would you like to buy? (0-{products[ChosenItem - 1].Quantity})");
                int HowManyBought = Validators.ValidateInt(Console.ReadLine());
                HowManyBought = Validators.IsQuantityAvailable(HowManyBought, products, ChosenItem);

                products[ChosenItem - 1].Quantity = products[ChosenItem - 1].Quantity - HowManyBought;
                cart[ChosenItem - 1].Quantity = cart[ChosenItem - 1].Quantity + HowManyBought;

                PrintCart(cart);

                Console.WriteLine("Would you like to continue shopping? (y/n)");
                Continue = Validators.ValidateString(Console.ReadLine());
                Continue = Validators.YesOrNo(Continue);
            }
            Console.Clear();
            return Continue;
        }

        private static string CartLoop(List<Checkout> checkout, string remove)
        {//allows user to remove items/quantity from cart and loops until user request
            while (remove == "y")
            {
                Console.WriteLine($"What item would you like removed? (1-{checkout.Count()})");
                int ChosenRemove = Validators.ValidateInt(Console.ReadLine());
                ChosenRemove = Validators.IsCartOption(ChosenRemove, checkout);

                Cart.PrintHeadersR();
                checkout[ChosenRemove - 1].PrintCheckout();
                Console.WriteLine();
                Console.WriteLine($"How many would you like to remove? (0-{checkout[ChosenRemove - 1].Quantity})");
                int NumberRemoved = Validators.ValidateInt(Console.ReadLine());
                NumberRemoved = Validators.IsQuantityAvailable2(NumberRemoved, checkout, ChosenRemove);

                checkout[ChosenRemove - 1].Quantity = checkout[ChosenRemove - 1].Quantity - NumberRemoved;

                PrintCheckout(checkout);
                Console.WriteLine();

                Console.WriteLine("Would you like to remove more items from your cart? (y/n)");
                string RemoveMore = Validators.ValidateString(Console.ReadLine());
                remove = Validators.YesOrNo(RemoveMore);
            }

            return remove;
        }
        private static void Checkout(double Total)
        {//takes and verifies user payment information
            Console.WriteLine("How would you like to pay? (cash/check/credit)");
            string PaymentOption = Validators.ValidateString(Console.ReadLine());
            PaymentOption = Validators.IsPayOption(PaymentOption);


            if (PaymentOption == "cash")
            {
                Console.Write("Please enter cash tendered: $");
                double CashTaken = Validators.ValidateDouble(Console.ReadLine());
                while (CashTaken < Total)
                {
                    Console.Write("Ensure you tender enough to cover the Total: Please re-enter- $");
                    CashTaken = Validators.ValidateDouble(Console.ReadLine());
                }
                double Change = Math.Round(CashTaken - Total, 2);
                Console.WriteLine();
                Console.WriteLine($"Your change is ${Change}");
            }
            else if (PaymentOption == "check")
            {
                Console.WriteLine("Please enter the check number");
                string CheckNumber = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(CheckNumber, (@"^\d{3}$"))))
                {
                    Console.WriteLine("Please enter a valid check number");
                    CheckNumber = Validators.ValidateString(Console.ReadLine());
                }

                Console.WriteLine("Please enter your routing number");
                string RoutingNum = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(RoutingNum, (@"^\d{9}$"))))
                {
                    Console.WriteLine("Please enter a valid routing number");
                    RoutingNum = Validators.ValidateString(Console.ReadLine());
                }

                Console.WriteLine("Please enter your account number");
                string AccountNum = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(AccountNum, (@"^\d{10}$"))))
                {
                    Console.WriteLine("Please enter a valid account number");
                    AccountNum = Validators.ValidateString(Console.ReadLine());
                }

            }
            else
            {
                Console.WriteLine("Please enter your card number (Visa/MasterCard");
                string CardNum = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(CardNum, (@"^\d{16}$"))))
                {
                    Console.WriteLine("Please enter a valid card number");
                    CardNum = Validators.ValidateString(Console.ReadLine());
                }

                Console.WriteLine("Please enter your zip code");
                string Zip = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(Zip, (@"^\d{5}$"))))
                {
                    Console.WriteLine("Please enter a valid zip code");
                    Zip = Validators.ValidateString(Console.ReadLine());
                }

                Console.WriteLine("Please enter your cvv");
                string Cvv = Validators.ValidateString(Console.ReadLine());
                while (!(Regex.IsMatch(Cvv, (@"^\d{3}$"))))
                {
                    Console.WriteLine("Please enter a valid cvv");
                    Cvv = Validators.ValidateString(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to print receipt");
            Console.ReadKey();
        }

        private static void EndProgram()
        {//shows user shopping session has ended
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping at GC Comics!");
            Console.WriteLine("Your receipt has been printed to receipt.txt");
        }

        private static void PrintFinalCheckout(List<Checkout> checkout, double SubTotal, double Tax, double Total)
        {//prints final cart and totals to user
            Console.Clear();
            PrintCheckout(checkout);
            Console.WriteLine($"SubTotal ----- ${SubTotal}");
            Console.WriteLine($"Tax ---------- ${Tax}");
            Console.WriteLine($"Total -------- ${Total}");
            Console.WriteLine("===========================");
            Console.WriteLine();
        }

        private static void Totals(List<Checkout> checkout, out double SubTotal, out double Tax, out double Total)
        {//calculates totals based on final checkout list
            SubTotal = 0;
            foreach (Checkout c in checkout)
            {
                SubTotal = SubTotal + Double.Parse(Convert.ToString(c.Quantity)) * c.Price;
            }
            Tax = Math.Round(SubTotal * .06, 2);
            Total = SubTotal + Tax;
        }

        private static List<Checkout> InstantiateCheckout(List<Cart> cart)
        {//instantiates checkout list for all user purchased items
            List<Checkout> checkout = new List<Checkout>();
            foreach (Cart c in cart)
            {
                if (c.Quantity > 0)
                {
                    Checkout temp = new Checkout(c.Name, c.Price, c.Quantity);
                    checkout.Add(temp);
                }
            }

            return checkout;
        }

        public static void PrintHeaders()
        {
            Console.Write("#".PadRight(4));
            Console.Write("Name".PadRight(30));
            Console.Write("Description".PadRight(40));
            Console.Write("Title".PadRight(35));
            //Console.Write("Item Number".PadRight(20));
            Console.Write("Price".PadRight(10));
            Console.WriteLine("Quantity");
            Console.Write("=".PadRight(4));
            Console.Write("====".PadRight(30));
            Console.Write("===========".PadRight(40));
            Console.Write("=====".PadRight(35));
            //Console.Write("===========".PadRight(20));
            Console.Write("=====".PadRight(10));
            Console.WriteLine("========");
        }
        public static void PrintHeadersOne()
        {
            Console.Write("Name".PadRight(30));
            Console.Write("Description".PadRight(40));
            Console.Write("Title".PadRight(35));
            //Console.Write("Item Number".PadRight(20));
            Console.Write("Price".PadRight(10));
            Console.WriteLine("Quantity");
            Console.Write("====".PadRight(30));
            Console.Write("===========".PadRight(40));
            Console.Write("=====".PadRight(35));
            //Console.Write("===========".PadRight(20));
            Console.Write("=====".PadRight(10));
            Console.WriteLine("========");
        }
        public static void PrintCloser()
        {
            Console.Write("=".PadRight(4));
            Console.Write("====".PadRight(30));
            Console.Write("===========".PadRight(40));
            Console.Write("=====".PadRight(35));
            //Console.Write("===========".PadRight(20));
            Console.Write("=====".PadRight(10));
            Console.WriteLine("========");
        }

        public static void PrintInfo(List<Products> products)
        {//Prints products available
            PrintHeaders();
            int x = 1;
            foreach (Products p in products)
            {
                Console.Write($"{x}) ".PadRight(4));
                p.PrintInfo1();
                //Console.WriteLine();
                x = x + 1;
            }
            PrintCloser();
        }

        private static void PrintCart(List<Cart> cart)
        {//prints cartlist
            Console.WriteLine("======Cart=======");
            int x = 1;
            foreach (Cart c in cart)
            {
                if (c.Quantity >= 1)
                {
                    c.PrintCartList(c,x);
                    x = x + 1;
                }
            }
            Console.WriteLine("==================");
            Console.WriteLine($"Subtotal: ${SubTotal(cart)}");
            Console.WriteLine("==================");
        }
        public static void PrintCheckout(List<Checkout> checkout)
        {//prints active cart to usser
            Console.WriteLine("======Cart-Checkout=======");
            Cart.PrintHeadersC();
            int x = 1;
            foreach (Checkout c in checkout)
            {
                Console.Write($"{x}) ".PadRight(4));
                c.PrintCheckout();
                x = x + 1;
            }
            Console.WriteLine("===========================");
            Console.WriteLine($"Subtotal: ${SubTotal(checkout)}");
            Console.WriteLine("===========================");
            Console.WriteLine();
        }
        public static double SubTotal(List<Checkout> checkout)
        {//calculates ongooing subtotal
            double subTotal = 0;
            foreach (Checkout c in checkout)
            {
                subTotal = subTotal + (c.Quantity * c.Price);
            }
            subTotal = Math.Round(subTotal, 2);
            return subTotal;
        }
        public static double SubTotal(List<Cart> cart)
        {//calculates ongooing subtotal
            double subTotal = 0;
            foreach (Cart c in cart)
            {
                subTotal = subTotal + (c.Quantity * c.Price);
            }
            subTotal = Math.Round(subTotal, 2);
            return subTotal;
        }

        private static void ClearCart(List<Cart> cart, List<Checkout> checkout)
        {//clears all cart/checkout quantities to 0 to re-run program
            foreach (Cart c in cart)
            {
                c.Quantity = 0;
            }
            foreach (Checkout c in checkout)
            {
                c.Quantity = 0;
            }
        }
        private static void PrintReceipt(List<Checkout> checkout, double SubTotal, double Tax, double Total)
        {//writes checkout to .txt file
            StreamWriter wr = new StreamWriter("../../Receipt.txt", true);

            wr.WriteLine("Thank you for shopping at GC Comics!");
            wr.WriteLine("1234 Grand Circus Park");
            wr.WriteLine("Detroit, MI 48207");
            wr.WriteLine();

            wr.Write("Name".PadRight(30));
            wr.Write("Price".PadRight(13));
            wr.WriteLine("Quantity");
            wr.Write("====".PadRight(30));
            wr.Write("=====".PadRight(13));
            wr.WriteLine("========");

            foreach (Checkout c in checkout)
            {
                wr.Write($"{c.Name.PadRight(30)}");
                wr.Write($"{c.Price}".PadRight(13));
                wr.WriteLine($"{c.Quantity}");
            }
            wr.Write("====".PadRight(30));
            wr.Write("=====".PadRight(13));
            wr.WriteLine("========");

            wr.WriteLine($"SubTotal ---------- ${SubTotal}");
            wr.WriteLine($"Tax --------------- ${Tax}");
            wr.WriteLine($"Total ------------- ${Total}");
            wr.WriteLine();

            wr.WriteLine(DateTime.Now);
            wr.WriteLine();

            wr.Close();

            //PrintFile("../../Receipt.txt");
        }
        private static string ShopAgain()
        {//allows the user to begin shopping experience again
            string ReRunProgram;
            Console.WriteLine("Would you like to shop again? (y/n)");
            ReRunProgram = Validators.ValidateString(Console.ReadLine());
            ReRunProgram = Validators.YesOrNo(ReRunProgram);
            Console.Clear();
            return ReRunProgram;
        }
        private static void ReSupplyLoop(List<Products> products, List<Cart> cart)
        {//allows user to add objects to products and loopd unitl user request
            Console.WriteLine("Press any key store or type 'y' to stock items");
            string Supplier = Validators.ValidateString(Console.ReadLine());
            //Supplier = Validators.YesOrNo(Supplier);

            string SupplyContinue;
            if (Supplier == "y")
            {
                SupplyContinue = "y";
            }
            else
            {
                SupplyContinue = "n";
            }
            while (SupplyContinue == "y")
            {
                if (Supplier == "y")
                {
                    PrintInfo(products);
                    Console.WriteLine();
                    Console.WriteLine($"What item are you resupplying? (1 - {products.Count}) or type {products.Count + 1} to add new item");
                    int SupplyItem = Validators.ValidateInt(Console.ReadLine());
                    SupplyItem = Validators.IsSupplyOption(SupplyItem, products);

                    if (SupplyItem == products.Count + 1)
                    {
                        string NewName, NewDescription, NewTitle;
                        double NewPrice;
                        int NewQuantity;
                        TakeNewInput(out NewName, out NewDescription, out NewTitle, out NewPrice, out NewQuantity);

                        AddNewProduct(products, NewName, NewDescription, NewTitle, NewPrice, NewQuantity);
                        AddNewCart(cart, NewName, NewPrice);

                        //writes new item to datainput file
                        StreamWriter wr = new StreamWriter("../../DataInput.txt", true);
                        wr.WriteLine();
                        wr.Write($"{NewName},{NewDescription},{NewTitle},81818181,{NewPrice.ToString()},{NewQuantity.ToString()}");
                        wr.Close();
                    }
                    else
                    {
                        PrintHeadersOne();
                        products[SupplyItem - 1].PrintInfo1();
                        Console.WriteLine();
                        Console.WriteLine("How many are you adding to store? (Max 15)");
                        int ReSupplyQuant = Validators.ValidateInt(Console.ReadLine());
                        ReSupplyQuant = Validators.IsReSupplyOption(ReSupplyQuant, products[SupplyItem - 1]);

                        products[SupplyItem - 1].Quantity = products[SupplyItem - 1].Quantity + ReSupplyQuant;
                    }
                }
                Console.WriteLine("Would you like to add more items? (y/n)");
                SupplyContinue = Validators.ValidateString(Console.ReadLine());
                SupplyContinue = Validators.YesOrNo(SupplyContinue);
            }
            Console.Clear();
        }
        private static void AddNewCart(List<Cart> cart, string NewName, double NewPrice)
        {// adds obj to cart
            Cart newcart = new Cart();
            newcart.Name = NewName;
            newcart.Price = Math.Round(NewPrice, 2);
            newcart.Quantity = 0;
            cart.Add(newcart);
        }

        private static void AddNewProduct(List<Products> products, string NewName, string NewDescription, string NewTitle, double NewPrice, int NewQuantity)
        {//adds obj to products
            Products newprod = new Products();
            newprod.NAME = NewName;
            newprod.Description = NewDescription;
            newprod.Title = NewTitle;
            newprod.Price = Math.Round(NewPrice, 2);
            newprod.Quantity = NewQuantity;
            products.Add(newprod);
        }

        private static void TakeNewInput(out string NewName, out string NewDescription, out string NewTitle, out double NewPrice, out int NewQuantity)
        {//takes and validates supply product category
            Console.WriteLine("What is the product Name?");
            NewName = Validators.ValidateString(Console.ReadLine());
            NewName = Validators.IsRealInput(NewName);
            Console.WriteLine("What is the product Description?");
            NewDescription = Validators.ValidateString(Console.ReadLine());
            NewDescription = Validators.IsRealInput(NewDescription);
            Console.WriteLine("What is the product Title?");
            NewTitle = Validators.ValidateString(Console.ReadLine());
            NewTitle = Validators.IsRealInput(NewTitle);
            Console.WriteLine("What is the product's Price?");
            NewPrice = Validators.ValidateDouble(Console.ReadLine());
            NewPrice = Validators.IsRealInput(NewPrice);
            Console.WriteLine("How many are you adding to store? (Max 15)");
            NewQuantity = Validators.ValidateInt(Console.ReadLine());
            NewQuantity = Validators.IsUnderMax(NewQuantity);
        }

    }
}