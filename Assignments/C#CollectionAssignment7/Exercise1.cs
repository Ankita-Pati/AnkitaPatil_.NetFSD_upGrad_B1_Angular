using System;
using System.Collections.Generic;
using System.Linq;

namespace C_CollectionAssignment7
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public string Category;
    }

    internal class Exercise1
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name="Laptop", Price=60000, Category="Electronics"},
            new Product{Id=2, Name="Phone", Price=20000, Category="Electronics"},
            new Product{Id=3, Name="Shoes", Price=1500, Category="Fashion"},
            new Product{Id=4, Name="Watch", Price=2500, Category="Fashion"},
            new Product{Id=5, Name="TV", Price=45000, Category="Electronics"},
            new Product{Id=6, Name="Bag", Price=800, Category="Fashion"},
            new Product{Id=7, Name="Tablet", Price=15000, Category="Electronics"},
            new Product{Id=8, Name="Headphones", Price=1200, Category="Electronics"},
            new Product{Id=9, Name="Chair", Price=3000, Category="Furniture"},
            new Product{Id=10, Name="Table", Price=7000, Category="Furniture"}
        };

            Console.WriteLine("All Products:");
            products.ForEach(p => Console.WriteLine($"{p.Id} {p.Name} {p.Price}"));

            Console.WriteLine("\nPrice > 1000:");
            var filtered = products.Where(p => p.Price > 1000);
            foreach (var p in filtered)
                Console.WriteLine(p.Name);

            Console.WriteLine("\nSorted Ascending:");
            var asc = products.OrderBy(p => p.Price);
            foreach (var p in asc)
                Console.WriteLine(p.Name + " " + p.Price);

            Console.WriteLine("\nSorted Descending:");
            var desc = products.OrderByDescending(p => p.Price);
            foreach (var p in desc)
                Console.WriteLine(p.Name + " " + p.Price);

            // Remove by Id
            products.RemoveAll(p => p.Id == 3);

            // Bonus: Filter by category
            Console.WriteLine("\nElectronics:");
            var electronics = products.Where(p => p.Category == "Electronics");
            foreach (var p in electronics)
                Console.WriteLine(p.Name);
        }
    }
}