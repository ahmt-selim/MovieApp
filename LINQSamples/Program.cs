using LINQSamples.Data;
using System;
using System.Linq;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.ToList();
                var products = db.Products.Select(p => p.ProductName).ToList();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }
            }
            Console.ReadLine();
        }
    }
}
