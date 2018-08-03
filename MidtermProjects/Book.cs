using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Book : Products

    {
        public Book(string nam, string des, string tit, string ite, double pri) :
                base(nam, des, tit, ite, pri)

        {
            Console.WriteLine($"Name: {NAME}, Description: {Description}, Title: {Title}, Item Number: {ItemNum}, Price:{Price:C}");
        }
    }

    public void PrintInfo()
    { 

        Products prod1, prod2, prod3;

        prod1 = new Products("Venom meets Carnage", "volume 1 issue 12 47 pages.", "Venom\'s Revenge", "234535", 5.99);
        prod2 = new Products("The beginning of Wolverine", "Volume 1 issue 1", "Wolverine Genesis", "464848293", 6.99);
        prod3 = new Products("Tacos and Mercs", " Volume 3 issue 24", "Deadpool lives", "2737483746", 11.99);

        List<Products> products = new List<Products>() { prod1, prod2, prod3 };

        
    }
    
}
