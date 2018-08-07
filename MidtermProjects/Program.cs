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
            List<Products> products = InstantiateProductList();
            List<Cart> cart = InstantiateCartList();

            Console.WriteLine("Welcome to GC Comics!");

            string Continue = "y";
            while (Continue == "y")
            {
                Console.WriteLine("Press any key to view inventory");
                Console.ReadKey();

                PrintInfo(products);

                Console.WriteLine($"What item would you like to purchase? (1-{products.Count()})");
                int ChosenItem = Validators.ValidateInt(Console.ReadLine());
                ChosenItem = Validators.IsProductOption(products, ChosenItem);

                PrintHeaders();
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

            List<Checkout> checkout = InstantiateCheckout(cart);

            PrintCheckout(checkout);
            Console.WriteLine();

            Console.WriteLine("Would you like to remove any items from your cart? (y/n)");
            string remove = Validators.ValidateString(Console.ReadLine());
            remove = Validators.YesOrNo(remove);

            while (remove == "y")
            {
                Console.WriteLine($"What item would you like removed? (1-{checkout.Count()})");
                int ChosenRemove = Validators.ValidateInt(Console.ReadLine());
                ChosenRemove = Validators.IsCartOption(ChosenRemove, checkout);

                PrintHeaders();
                checkout[ChosenRemove - 1].PrintCheckout();
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

            double SubTotal, Tax, Total;
            Totals(checkout, out SubTotal, out Tax, out Total);

            PrintFinalCheckout(checkout, SubTotal, Tax, Total);
            Console.WriteLine();

            Console.WriteLine("How would you like to pay? (cash/check/credit)");
            string PaymentOption = Validators.ValidateString(Console.ReadLine());
            PaymentOption = Validators.IsPayOption(PaymentOption);

            //FILL OUT
            if (PaymentOption == "cash")
            {
                //take cash
            }
            else if (PaymentOption == "check")
            {
                //take check info
            }
            else
            {
                //take card info
            }

            PrintReceipt(checkout, SubTotal, Tax, Total);



            Console.Clear();
            PrintFinalCheckout(checkout, SubTotal, Tax, Total);

            EndProgram();

            #region OldComments

            //Console.WriteLine("Which category would you like to buy from? (Toys, Books, Games)");
            //string cat = Validators.ValidateString(Console.ReadLine());
            //cat = Validators.IsOption(cat);

            //bool goAgain = true;
            ////makes sure the user puts in the right input
            ////list cart imported from the cart class
            ////printagain = 0 
            //while (goAgain)
            //{
            //    //if printagain = 1 cw("Pick another category") takes in cat value and runs through again
            //    if (cat == "toys")//shows toys
            //    {
            //        //show toys, ask if they would like to add any to cart 
            //        //while addtocart == true
            //        //ask if they would like to add anything else to cart 
            //        //outside the loop it asks if they want to go to another category
            //        //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
            //        goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //    }
            //    else if (cat == "books")//shows books
            //    {


            //        //show books, ask if they would like to add any to cart 
            //        //while addtocart == true
            //        //ask if they would like to add anything else to cart 
            //        //outside the loop it asks if they want to go to another category
            //        //if yes then  printagain = 1 and goAgain = true the program ask for user to input another catgory
            //        goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //    }
            //    else if (cat == "games")//shows game
            //    {

            //        //show games, ask if they would like to add any to cart 
            //        //while addtocart == true
            //        //ask if they would like to add anything else to cart 
            //        //outside the loop it asks if they want to go to another category
            //        //if yes then printagain = 1 and goAgain = true the program ask for user to input another catgory
            //        goAgain = false;// if they are done adding items to the cart and would like to go to check out
            //    }
            //    else //light validation
            //    {
            //        while (!(Regex.IsMatch(cat, "^[tT][oO][yY][sS]|[tT][oO][yY]|[bB][oO][oO][kK]|[bB][oO][oO][kK][sS]|[bB][oO][oO][kK]|[gG][aA][mM][eE]|[gG][aA][mM][eE][sS]$")))
            //        {
            //            Console.WriteLine("Enter the right input");
            //            cat = Console.ReadLine();
            //            goAgain = true;
            //        }
            //    }
            //}
            //checkout code
            ///////////////////////////////
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
            #endregion
        }

        private static void EndProgram()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping at GC Comics!");
            Console.WriteLine("Your receipt has been printed to receipt.txt");
            Console.ReadKey();
        }

        private static void PrintFinalCheckout(List<Checkout> checkout, double SubTotal, double Tax, double Total)
        {
            Console.Clear();
            PrintCheckout(checkout);
            Console.WriteLine($"SubTotal ----- ${SubTotal}");
            Console.WriteLine($"Tax ---------- ${Tax}");
            Console.WriteLine($"Total -------- ${Total}");
            Console.WriteLine("===========================");
        }

        private static void Totals(List<Checkout> checkout, out double SubTotal, out double Tax, out double Total)
        {
            SubTotal = 0;
            foreach (Checkout c in checkout)
            {
                SubTotal = SubTotal + Double.Parse(Convert.ToString(c.Quantity)) * c.Price;
            }
            Tax = SubTotal * .06;
            Total = SubTotal + Tax;
        }

        private static List<Checkout> InstantiateCheckout(List<Cart> cart)
        {
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

        private static List<Products> InstantiateProductList()
        {
            Book prod1 = new Book("Venom meets Carnage", "volume 1 issue 12", "Venom\'s Revenge", "234535", 5.99, 3);
            Book prod2 = new Book("The beginning of Wolverine", "Volume 1 issue 1", "Wolverine Genesis", "464848293", 6.99, 5);
            Book prod3 = new Book("Tacos and Mercs", "Volume 3 issue 24", "Deadpool lives", "2737483746", 11.99, 6);
            Book prod4 = new Book("Amazing Spider-Man #3", "Volume 4 issue 3", "Mavel Spider Man", "47477444774", 3.99, 9);
            Book prod5 = new Book("Captain America #1", "Volume 3, issue 1", "Captain America is America", "4747755", 3.99, 9);
            Book prod6 = new Book("The Joker vs. IronMan", "Volume never", "Universes Collide", "66675748", 12.99, 10);
            Book prod7 = new Book("Fantastic Four", "Episode 34", "The Thing Likes Rock Music", "45555555", 3.99, 4);
            Book prod8 = new Book("Robo Cop", "Episode 313", "The Coolest Superhero from Detroit", "313131313", 3.13, 13);
            Book prod9 = new Book("Spinal Tap", "Episode 11", "This One Goes to Eleven", "11111111111", 11.00, 11);
            Game prod10 = new Game("UNO", "No description here", "UNO Classic", "234234234535", 6.99, 6);
            Game prod11 = new Game("Poker Set", "52 Cards Chips and Dealer Button", "Hoyles Classic Poker Set", "4243364848293", 46.99, 5);
            Game prod12 = new Game("Cards Against Humanity", "The Starter Deck", "CAH Starter Deck", "27245337483746", 24.99, 2);
            Game prod13 = new Game("Hot Potato", "Just an actual baked potato", "Hot Potato Game", "4747473983983", 1.79, 1);
            Toy prod14 = new Toy("Pikachu Plush", "14 inch plush Pikachu", "Pika Pika Pakachu", "47438347282374", 24.67, 5);
            Toy prod15 = new Toy("Batman Bobblehead", "4 inch Batman Begins Bobblehead", "BatBobble", "464247842848293", 19.99, 7);
            Toy prod16 = new Toy("Superman 2 Hero", "Classic AF with opposable thumbs", "Superman action", "23435454746", 27.99, 5);
            Toy prod17 = new Toy("Amazing Spiderman Figure", "Classic AF with 385 feet of web", "Amazing Spiderman", "247477373", 9.99, 3);
            List<Products> products = new List<Products>() { prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10, prod11, prod12, prod13, prod14, prod15, prod16, prod17 };
            return products;
        }
        public static void PrintHeaders()
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
            Console.Write("====".PadRight(30));
            Console.Write("===========".PadRight(40));
            Console.Write("=====".PadRight(35));
            //Console.Write("===========".PadRight(20));
            Console.Write("=====".PadRight(10));
            Console.WriteLine("========");
        }

        public static void PrintInfo(List<Products> products)
        {
            PrintHeaders();
            foreach (Products p in products)
            {
                p.PrintInfo1();
                //Console.WriteLine();
            }
            PrintCloser();
        }
        private static List<Cart> InstantiateCartList()
        {
            Cart cart1 = new Cart("Venom meets Carnage", 5.99, 0);
            Cart cart2 = new Cart("The beginning of Wolverine", 6.99, 0);
            Cart cart3 = new Cart("Tacos and Mercs", 11.99, 0);
            Cart cart4 = new Cart("Amazing Spider-Man #3", 3.99, 0);
            Cart cart5 = new Cart("Captain America #1", 3.99, 0);
            Cart cart6 = new Cart("The Joker vs. IronMan", 12.99, 0);
            Cart cart7 = new Cart("Fantastic Four", 3.99, 0);
            Cart cart8 = new Cart("Robo Cop", 3.13, 0);
            Cart cart9 = new Cart("Spinal Tap", 11.00, 0);
            Cart cart10 = new Cart("UNO", 6.99, 0);
            Cart cart11 = new Cart("Poker Set", 46.99, 0);
            Cart cart12 = new Cart("Cards Against Humanity", 24.99, 0);
            Cart cart13 = new Cart("Hot Potato", 1.79, 0);
            Cart cart14 = new Cart("Pikachu Plush", 24.67, 0);
            Cart cart15 = new Cart("Batman Bobblehead", 19.99, 0);
            Cart cart16 = new Cart("Superman 2 Hero", 27.99, 0);
            Cart cart17 = new Cart("Amazing Spiderman Action Figure", 9.99, 0);
            List<Cart> cart = new List<Cart>() { cart1, cart2, cart3, cart4, cart5, cart6, cart7, cart8, cart9, cart10, cart11, cart12, cart13, cart14, cart15, cart16, cart17 };
            return cart;
        }
        private static void PrintCart(List<Cart> cart)
        {//prints cartlist
            Console.WriteLine("======Cart=======");
            foreach (Cart c in cart)
            {
                if (c.Quantity >= 1)
                {
                    c.PrintCartList(c);
                }
            }
            Console.WriteLine("==================");
        }
        public static void PrintCheckout(List<Checkout> checkout)
        {
            Console.WriteLine("======Cart-Checkout=======");
            Cart.PrintHeadersC();
            foreach (Checkout c in checkout)
            {
                c.PrintCheckout();
            }
            Console.WriteLine("===========================");
        }
        private static void PrintReceipt(List<Checkout> checkout, double SubTotal, double Tax, double Total)
        {
            StreamWriter wr = new StreamWriter("../../Receipt.txt", true);

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


            wr.WriteLine($"SubTotal ---------- ${SubTotal}");
            wr.WriteLine($"Tax --------------- ${Tax}");
            wr.WriteLine($"Total ------------- ${Total}");

            wr.Close();

            //PrintFile("../../Receipt.txt");
        }

    }
}
