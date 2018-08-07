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
