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
        #endregion

        //constructor to set default values to NA and zero

        public Products()
        {
            NAME = "not assigned";
            Description = "not assigned";
            Title = "NA";
            ItemNum = "00000000000";
            Price = 0;
        }

        public Products(string nam, string des, string tit, string ite, double pri)
        {
            NAME = nam;
            Description = des;
            Title = tit;
            ItemNum = ite;
            Price = pri;
        }
        public virtual void PrintInfo(List<Products>products)
        {
            Console.WriteLine($"Name: {NAME}, Description: {Description}, Title: {Title}, Item Number: {ItemNum}, Price:{Price:C}");
        }

  





    }
}
