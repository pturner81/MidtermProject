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
