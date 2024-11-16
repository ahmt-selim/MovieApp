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
                Ders2(db);

            }
            Console.ReadLine();
        }

        private static void Ders2(NorthwindContext db)
        {
            //var products = db.Products.Select(p=> new { p.ProductName, p.UnitPrice }).Where(p => p.UnitPrice > 18).ToList();
            //var products = db.Products.Select(p => new { p.ProductName, p.UnitPrice,p.CategoryId }).Where(p => p.UnitPrice > 18).ToList();
            //Where bloğunu selectten önce yazarsak where bloğundaki ilgili kolon selectte olmasa bile where de görebiliriz.
            //foreach (var p in products)
            //{
            //    Console.WriteLine(p.ProductName + " " + p.UnitPrice);
            //}

            //Tüm çalışanların ad ve soyadını tek bir kolon şeklinde gitiriniz.
            var employess = db.Employees
                .Select(i => new { Fullname = i.FirstName + " " + i.LastName }).ToList();
            foreach (var item in employess)
            {
                Console.WriteLine(item.Fullname);
            }

            //Ürünler tablosundaki ilk 5 kaydı getiriniz.

            //var products = db.Products.Take(5).ToList();
            //foreach (var p in products)
            //{
            //    Console.WriteLine(p.ProductName + " " + p.ProductId);
            //}

            //Ürünler tablosundaki ikinci 5 kaydı getiriniz.

            var products = db.Products.Skip(5).Take(5).ToList();
            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName + " " + p.ProductId);
            }
        }

        private static void Ders1(NorthwindContext db)
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
    }
}
