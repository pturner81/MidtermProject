using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Cart
    {
        #region Publics
        private string name;
        //private string title;
        private double price;
        private int quantity;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        //public string Title
        //{
        //    set { title = value; }
        //    get { return title; }

        //}
        public double Price
        {
            set { price = value; }
            get { return price; }
        }

        public int Quantity
        {
            set { quantity = value; }
            get { return quantity; }
        }
        #endregion
        public Cart()
        {
            Name = "not assigned";
            Price = 0;
            Quantity = 0;
        }

        public Cart(string nam, double pri, int qua)
        {
            Name = nam;
            Price = pri;
            Quantity = qua;
        }
        public virtual void PrintCartList(Object c, int x)
        {
            PrintHeadersC();
            if (Quantity >= 1)
            {
                Console.Write($"{x}) ".PadRight(4));
                Console.Write(Name.PadRight(30));
                //Console.Write(Title);
                Console.Write($"${Price}".PadRight(10));
                Console.WriteLine(Quantity);
            }
        }
        public static void PrintHeadersC()
        {
            Console.Write($"#".PadRight(4));
            Console.Write("Name".PadRight(30));
            Console.Write("Price".PadRight(10));
            Console.WriteLine("Quantity");
            Console.Write("=".PadRight(4));
            Console.Write("====".PadRight(30));
            Console.Write("=====".PadRight(10));
            Console.WriteLine("========");
        }

    }
    
}
