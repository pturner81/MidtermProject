using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Book : Products

    {
        public Book(string nam, string des, string tit, string ite, double pri, int qua) :
                base(nam, des, tit, ite, pri, qua)

        {
            Console.WriteLine($"Name: {NAME}, Description: {Description}, Title: {Title}, Item Number: {ItemNum}, Price:{Price:C}, Quantity:{Quantity}");
        }

        public void PrintInfo1()
        {

            Book prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9;

            prod1 = new Book("Venom meets Carnage", "volume 1 issue 12 47 pages.", "Venom\'s Revenge", "234535", 5.99, 3);
            prod2 = new Book("The beginning of Wolverine", "Volume 1 issue 1", "Wolverine Genesis", "464848293", 6.99, 5);
            prod3 = new Book("Tacos and Mercs", " Volume 3 issue 24", "Deadpool lives", "2737483746", 11.99, 6);
            prod4 = new Book("Amazing Spider-Man #3", "Volume 4 issue 3", "Mavel Spider Man", "47477444774", 3.99, 9);
            prod5 = new Book("Captain America #1", "Volume 3, issue 1", "Captain America is America", "4747755", 3.99, 9);
            prod6 = new Book("The Joker vs. IronMan", "Volume never", "Universes Collide", "66675748", 12.99, 10);
            prod7 = new Book("Fantastic Four", "Episode 34", "The Thing Likes Rock Music", "45555555", 3.99, 4);
            prod8 = new Book("Robo Cop", "Episode 313", "The Coolest Superhero from Detroit", "313131313", 3.13, 13);
            prod9 = new Book("Spinal Tap", "Episode 11", "This One Goes to Eleven", "11111111111", 11.00, 11);

            

            List<Book> products = new List<Book>() { prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9 };
        }

        

        public void PrintList(List<Book> products)
        {
            foreach (Book prod in products)
            {
                PrintList(products);
            }
        }
        
    }
   
 
    
}
