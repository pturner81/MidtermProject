﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjects
{
    class Game : Products

    {
        public Game(string nam, string des, string tit, string ite, double pri, int qua) :
                base(nam, des, tit, ite, pri, qua)

        {
            //Console.WriteLine($"Name: {NAME}, Description: {Description}, Title: {Title}, Item Number: {ItemNum}, Price:{Price:C}, Quantity:{Quantity}");
        }

        public void PrintInfo1()
        {

            Game prod1, prod2, prod3, prod4;

            prod1 = new Game("UNO", "No description here", "UNO Classic", "234234234535", 6.99, 6);
            prod2 = new Game("Poker Set", "52 Cards Chips and Dealer Button", "Hoyles Classic Poker Set", "4243364848293", 46.99, 5);
            prod3 = new Game("Cards Against Humanity", " The Starter Deck", "Cards Against Humanity Starter Deck", "27245337483746", 24.99, 2);
            prod4 = new Game("Hot Potato", "Just an actual baked potato", "Hot Potato Game", "4747473983983", 1.79, 1);


            List<Game> products = new List<Game>() { prod1, prod2, prod3, prod4 };
        }



        public void PrintList(List<Game> products)
        {
            foreach (Game prod in products)
            {
                PrintList(products);
            }
        }

    }



}

