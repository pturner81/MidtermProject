using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Toy : Products
    {

        public Toy(string nam, string des, string tit, string ite, double pri, int qua) :
                    base(nam, des, tit, ite, pri, qua)

        {
            //Console.WriteLine($"Name: {NAME}, Description: {Description}, Title: {Title}, Item Number: {ItemNum}, Price:{Price:C}, Quantity:{Quantity}");
        }

        public void PrintInfo1()
        {

            Toy prod1, prod2, prod3, prod4;

            prod1 = new Toy("Pikachu Plush", "14 inch plush Pikachu", "Pika Pika Pakachu", "47438347282374", 24.67, 5);
            prod2 = new Toy("Batman Bobblehead", "4 inch Batman Begins Bobblehead", "BatBobble", "464247842848293", 19.99, 7);
            prod3 = new Toy("Superman 2 Hero", " Classic superman action figure with opposable thumbs", "Superman action", "23435454746", 27.99, 5);
            prod4 = new Toy("Amazing Spiderman Action Figure", "Classic spiderman action figure with 385 feet of web", "Amazing Spiderman", "247477373", 9.99,3);

            List<Toy> products = new List<Toy>() { prod1, prod2, prod3, prod4 };
        }



        public void PrintList(List<Toy> products)
        {
            foreach (Toy prod in products)
            {
                PrintList(products);
            }
        }

    }



}
