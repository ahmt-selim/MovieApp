using LINQSamples.Data;
using System;
using System.Linq;

namespace LINQSamples
{
    class ProductModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.ToList();
                //var products = db.Products.Select(p => p.ProductName).ToList();
                // birden fazla kolon getirmek istediğimizde bu şekilde kullanılır.
                //var products = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).ToList();

                //var products = db.Products.Select(p => 
                //new ProductModel{ Name=p.ProductName, Price=p.UnitPrice }).ToList();
                //foreach (var p in products)
                //{
                //    Console.WriteLine(p.Name + " " + p.Price);
                //}

                var product = db.Products.First();//İlk satırı döner. Eğer bir satır gelmesse hata vereceği için FirstOrDefault() kullanılır.
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }
            Console.ReadLine();
        }
    }
}
