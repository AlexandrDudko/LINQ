using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Product " + i,
                    Energy = rnd.Next(10, 12)
                };
                products.Add(product);
            }

            var result = from item in products
                         where item.Energy < 200 
                         select item;
            var result2 = products.Where(item => item.Energy < 200 || item.Energy > 400);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            var selectCollection = products.Select(product => product.Energy);
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }

            var orderbyCollection = products.OrderBy(product => product.Energy)
                                            .ThenBy(product => product.Name);
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }

            var groupbyCollection = products.GroupBy(product => product.Energy);
            foreach (var key in groupbyCollection)
            {
                Console.WriteLine($"Key: {key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($"Products name: {item.Name}");
                }
            }
        }
    }
}
