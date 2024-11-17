using LINQSamples.Data;
using System;
using System.Collections.Generic;
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
                var result = db.Products.Count();
                var result1 = db.Products.Count(i => i.UnitPrice > 10 && i.UnitPrice < 30);
                var result2 = db.Products.Count(i => i.Discontinued);
                var result3 = db.Products.Count(i => !i.Discontinued);
                var result4 = db.Products.Min(p => p.UnitPrice);//Minimum unit price
                var result5 = db.Products.Max(p => p.UnitPrice);//maksimum unit price
                var result6 = db.Products.Average(p => p.UnitPrice);//unitprice ların ortalaması
                var result7 = db.Products.Sum(p => p.UnitsInStock);//unitinstock kolonunu toplar

                var res = db.Products.OrderBy(p=>p.UnitPrice).ToList();//OrderBy sıralama işlemi yapar. Varsayılan olarak artan sıralama yani küçükten büyüğe sıralar.
                
                foreach (var item in res)
                {
                    Console.WriteLine(item.ProductName + " " + item.UnitPrice);
                }

                Console.WriteLine(result);
                Console.WriteLine(result1);
                Console.WriteLine(result2);
                Console.WriteLine(result3);
                Console.WriteLine(result4);
                Console.WriteLine(result5);
                Console.WriteLine(result6);
                Console.WriteLine(result7);

                var res1 = db.Products.OrderByDescending(p => p.UnitPrice).ToList();//OrderBy sıralama işlemi yapar. Varsayılan olarak azalan sıralama yani büyükten küçüğe sıralar.

                foreach (var item in res1)
                {
                    Console.WriteLine(item.ProductName + " " + item.UnitPrice);
                }
            }
            Console.ReadLine();
        }

        private static void Ders3()
        {
            //using (var db = new NorthwindContext())
            //{
            //    var p1 = new Product() { ProductName = "Yeni Ürün 1" };
            //    db.Products.Add(p1);
            //    db.SaveChanges();
            //    Console.WriteLine("veri eklendi.");
            //    Console.WriteLine(p1.ProductId);

            //}
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.Where(c => c.CategoryName == "Produce").FirstOrDefault();

                var p1 = new Product() { ProductName = "Yeni Ürün 9", Category = category };
                var p2 = new Product() { ProductName = "Yeni Ürün 10", Category = category };
                //var products = new List<Product>() { p1, p2 };
                //db.Products.AddRange(products); //AddRange ile liste halinde ekleme yapılabilir.
                category.Products.Add(p1);
                category.Products.Add(p2);//Category entities'i içinde Product ICollection ı bulunduğu için bu şekilde kategori üzerinden ürün eklemesi de yapılabilir.

                db.SaveChanges();
                Console.WriteLine("veriler eklendi.");
                Console.WriteLine(p1.ProductId);
                Console.WriteLine(p2.ProductId);

            }
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
