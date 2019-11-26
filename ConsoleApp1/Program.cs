using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Insect bee = new Insect("Bee", 6, 3, 2.4, 10000);
                Console.WriteLine(bee);
                Console.WriteLine($"The bee can produce {bee[2]} children in the space of 2 years.");
                Console.WriteLine($"The bee can produce {bee.ProductivityPerLife()} children in the space of its life.");
                if (bee) Console.WriteLine("The bee has even amount legs and flies.");
                else Console.WriteLine("Either the bee has wrong amount legs or flies.");
                Insect spider = new Insect("Spider", 8, 0, 1.8, 6000);
                Console.WriteLine(spider);
                Console.WriteLine($"The bee can produce {spider[4]} children in the space of 4 years.");
                Insect beeSpider = bee + spider;
                Console.WriteLine(beeSpider);
                Insect beeMinusSpider = bee - spider;
                Console.WriteLine(beeMinusSpider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
