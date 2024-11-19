using LINQSamples.Data;
using Microsoft.EntityFrameworkCore;
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
                //Birden fazla tablodan veri çekmek istediğimizde:
                //var products = db.Products.Include(p => p.Category).Where(p => p.Category.CategoryName == "Beverages").ToList();

                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.ProductName + " " + item.CategoryId + " " + item.Category.CategoryName);//Burada CategoryName alanı Include ile eklediğimiz Category tablosundan geliyor.
                //}

                //2. Yöntem:
                //var products = db.Products
                //    .Where(p => p.Category.CategoryName == "Beverages")
                //    .Select(p => new
                //    {
                //        name = p.ProductName,
                //        id = p.ProductId,
                //        categoryname = p.Category.CategoryName
                //    }).ToList();
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.name + " " + item.id + " " + item.categoryname);
                //}
                ////---
                ////var categories = db.Categories.Where(c => c.Products.Count() == 0).ToList();//Hiçbir üründe olmayan kategorileri getirir.
                //var categories = db.Categories.Where(c => c.Products.Any()).ToList();//Any en az bir kayıt olanları döner.
                //foreach (var item in categories)
                //{
                //    Console.WriteLine(item.CategoryName);
                //}

                //extension methods= Şimdiya kadar sql sorgusu üretmek için kullanılan metot. Bu metotta iki tablo left join ile birleştirilir. inner join kullanmak için aşağıdaki yöntem kullanılır.
                //query exoressions:

                //var products = (from p in db.Products
                //                where p.UnitPrice>10
                //                select p).ToList();

                var products = (from p in db.Products
                                join s in db.Suppliers on p.SupplierId equals s.SupplierId
                                select new
                                {
                                    p.ProductName,
                                    contactName = s.ContactName,
                                    companyName = s.ContactName
                                }).ToList();


            }
            Console.ReadLine();
        }

        private static void Ders8()
        {
            using (var db = new NorthwindContext())
            {
                //Yöntem1
                //var p = db.Products.Find(84);
                //if (p != null)
                //{
                //    db.Products.Remove(p);
                //    db.SaveChanges();
                //    Console.WriteLine("Veri silindi.");
                //}
                //Yöntem2
                //var p = new Product() { ProductId = 87 };
                //db.Entry(p).State = EntityState.Deleted;//İlgli kayıtla ilgili change tracking işlemi başlatır. EntityState ile silme işlemi sağlanır.
                //db.SaveChanges();
                //Console.WriteLine("Veri silindi.");

                //Toplu silme
                var p1 = new Product() { ProductId = 82 };
                var p2 = new Product() { ProductId = 83 };
                var products = new List<Product>() { p1, p2 };
                db.Products.RemoveRange(products);
                db.SaveChanges();
            }
        }

        private static void Ders7()
        {
            using (var db = new NorthwindContext())
            {
                var product = db.Products.Find(1);// id si 1 olan ürünün bulur ama henüz getirmez.
                //Bu şekilde de select sorgusu atmadan veri güncelleyebiliriz.
                Console.WriteLine(product.ProductName);
                if (product != null)
                {
                    product.UnitPrice = 28;

                    db.Update(product);//ilgili tablodaki bütün kolonlara güncelleme sorgusu atılır.
                    db.SaveChanges();
                }
            }
        }

        private static void Ders6()
        {
            using (var db = new NorthwindContext())
            {
                //Bir select işlemi yapmadan sadece update sorgusu ile veri güncellenmek istendiğinde Attach metodu kullanılır.
                var p = new Product() { ProductId = 1 };
                db.Products.Attach(p);//İlgili tablodayla ilgili bir change tracking işlemi başlatır.
                p.UnitsInStock += 10;
                db.SaveChanges();
            }
        }

        private static void Ders5()
        {
            using (var db = new NorthwindContext())
            {
                //change tracking: Bir veri contextten çağırıldığında arkada ilgili getirilen tabloda yapılan değişiklikleri tutan rapordur.
                //Eğer getirilen veri sadece kullanıcıya gösterilecekse kaıt güncellemsei yapılmayacakta .AsNoTracking ile bu rapor tutulmaz.
                var product = db.Products
                    //.AsNoTracking()
                    .FirstOrDefault(p => p.ProductId == 1);
                if (product != null)
                {
                    product.UnitsInStock += 10;//Sadece ilgili kolon üçün update sorgusu yazılır.
                    db.SaveChanges();
                    Console.WriteLine("Veri güncellendi.");
                }

            }
        }

        private static void Ders4()
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

                var res = db.Products.OrderBy(p => p.UnitPrice).ToList();//OrderBy sıralama işlemi yapar. Varsayılan olarak artan sıralama yani küçükten büyüğe sıralar.

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
