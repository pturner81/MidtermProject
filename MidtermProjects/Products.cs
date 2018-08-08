using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Products
    {
        #region Publics
        private string name;
        private string description;
        private string title;
        private string itemNum;
        private double price;
        private int quantity;

        public string NAME
        {
            set { name = value; }
            get { return name; }
        }

       public static void Add(Products products)

        {

        }
        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public string Title
        {
            set { title = value; }
            get { return title; }

        }

        public string ItemNum
        {
            set { itemNum = value; }
            get { return itemNum; }
        }


        public double Price
        {
            set { price = value; }
            get { return price; }
        }

        public int Quantity
        {
            set {quantity = value; }
            get { return quantity; }
        }
        #endregion

        //constructor to set default values to NA and zero

        public Products()
        {
            NAME = "not assigned";
            Description = "not assigned";
            Title = "NA";
            ItemNum = "00000000000";
            Price = 0;
            Quantity = 0;
        }

        public Products(string nam, string des, string tit, string ite, double pri, int qua)
        {
            NAME = nam;
            Description = des;
            Title = tit;
            ItemNum = ite;
            Price = pri;
            Quantity = qua;
        }
        public virtual void PrintInfo1()
        {
            Console.Write(NAME.PadRight(30));
            Console.Write(Description.PadRight(40));
            Console.Write(Title.PadRight(35));
            //Console.Write(ItemNum.PadRight(20));
            Console.Write($"${Price}".PadRight(13)); 
            Console.WriteLine(Quantity);
        }

    }
}
//private static List<Products> InstantiateProductList()
//{//Instantiates product list
//    Book prod1 = new Book("Venom meets Carnage", "volume 1 issue 12", "Venom\'s Revenge", "234535", 5.99, 3);
//    Book prod2 = new Book("Begnining of Wolverine", "Volume 1 issue 1", "Wolverine Genesis", "464848293", 6.99, 5);
//    Book prod3 = new Book("Tacos and Mercs", "Volume 3 issue 24", "Deadpool lives", "2737483746", 11.99, 6);
//    Book prod4 = new Book("Amazing Spider-Man #3", "Volume 4 issue 3", "Mavel Spider Man", "47477444774", 3.99, 9);
//    Book prod5 = new Book("Captain America #1", "Volume 3, issue 1", "Captain America is America", "4747755", 3.99, 9);
//    Book prod6 = new Book("The Joker vs. IronMan", "Volume never", "Universes Collide", "66675748", 12.99, 10);
//    Book prod7 = new Book("Fantastic Four", "Episode 34", "The Thing Likes Rock Music", "45555555", 3.99, 4);
//    Book prod8 = new Book("Robo Cop", "Episode 313", "The Coolest Superhero from Detroit", "313131313", 3.13, 13);
//    Book prod9 = new Book("Spinal Tap", "Episode 11", "This One Goes to Eleven", "11111111111", 11.00, 11);
//    Game prod10 = new Game("UNO", "No description here", "UNO Classic", "234234234535", 6.99, 6);
//    Game prod11 = new Game("Poker Set", "52 Cards Chips and Dealer Button", "Hoyles Classic Poker Set", "4243364848293", 46.99, 5);
//    Game prod12 = new Game("Cards Against Humanity", "The Starter Deck", "CAH Starter Deck", "27245337483746", 24.99, 2);
//    Game prod13 = new Game("Hot Potato", "Just an actual baked potato", "Hot Potato Game", "4747473983983", 1.79, 1);
//    Toy prod14 = new Toy("Pikachu Plush", "14 inch plush Pikachu", "Pika Pika Pakachu", "47438347282374", 24.67, 5);
//    Toy prod15 = new Toy("Batman Bobblehead", "4 inch Batman Begins Bobblehead", "BatBobble", "464247842848293", 19.99, 7);
//    Toy prod16 = new Toy("Superman 2 Hero", "Classic AF with opposable thumbs", "Superman action", "23435454746", 27.99, 5);
//    Toy prod17 = new Toy("Amzng Spiderman Figure", "Classic AF with 385 feet of web", "Amazing Spiderman", "247477373", 9.99, 3);
//    List<Products> products = new List<Products>() { prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10, prod11, prod12, prod13, prod14, prod15, prod16, prod17 };
//    return products;
//}
