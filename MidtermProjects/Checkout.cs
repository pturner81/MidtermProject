using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Checkout
    {
        #region Publics
        private string name;
        private double price;
        private int quantity;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
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
        public Checkout()
        {
            Name = "not assigned";
            Price = 0;
            Quantity = 0;
        }

        public Checkout(string nam, double pri, int qua)
        {
            Name = nam;
            Price = pri;
            Quantity = qua;
        }
        public virtual void PrintCheckout()
        {
            Console.Write(Name.PadRight(30));
            Console.Write($"${Price}".PadRight(13));
            Console.WriteLine(Quantity);
        }
    }
}
