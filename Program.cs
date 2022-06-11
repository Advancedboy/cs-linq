using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_proj
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            #region
            //var collection = new List<int>();

            //for (int i = 1; i <= 10; i++)
            //{
            //    collection.Add(i);
            //}
            //var result = from item in collection
            //             where item <= 5
            //             select item;

            //var result2 = collection
            //                        .Where(item => item >= 5)
            //                        .Where(item => item % 2 == 0)
            //                        .OrderByDescending(item => item);

            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=============");
            //foreach(var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            var products = new List<Product>();
            for (int i = 1; i <= 50; i++)
            {
                var product = new Product()
                {
                    Name = $"Product {i}",
                    Energy = rnd.Next(10, 20)
                };
                products.Add(product);
            }

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}

            var energy = products.Where(item => item.Energy < 100);
            //Console.WriteLine("=====");
            //foreach (var item in energy)
            //{
            //    Console.WriteLine(item);
            //}
            var selectCollection = products.Select(product => product.Energy);

            //foreach(var item in selectCollection)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("=======");
            var orderbyCollection = products.OrderBy(product => product.Energy).ThenByDescending(product => product.Name);
            //foreach (var item in orderbyCollection)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=========");
            var groupByCollection = products.GroupBy(product => product.Energy);
            foreach (var group in groupByCollection)
            {
                Console.WriteLine($"Ключ: {group.Key}.");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
            }

            products.Reverse();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine(products.All(item => item.Energy == 10)); // true/false
            Console.WriteLine(products.Any(item => item.Energy == 10)); // true/false
            Console.WriteLine(products.Contains(products[5])); // true/false

            var array = new int[] { 1, 2, 3, 4, 5 };
            var array2 = new int[] { 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            
            var union = array.Union(array2);
            Console.WriteLine("=======");
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            var intersect = array.Intersect(array2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }

            var sum = array.Sum();
            var min = products.Min(p => p.Energy);
            var max = products.Max(p => p.Energy);
            var aggregate = array.Aggregate((x, y) => x * y);

            var sum2 = array.Skip(1).Sum(); //skip(1) пропускаем 1 элемент массива
            var sum3 = array.Take(2).Sum(); //take(2) выбираем 2 элемента массива
            
            var first = array.First(); // должен быть хотя бы 1 элемент в массиве
            var firstOrDefault = array.FirstOrDefault(); // если коллекция будет пустая
            var last = array.Last();
            var lastOrDefault = array.LastOrDefault(); // default для int = 0
            var elementAt = products.ElementAt(5); // получить элемент с индексом 5 
            var elementAtOrDefault = products.ElementAtOrDefault(5); // получить элемент с индексом 5 

            Console.WriteLine("=======");
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(aggregate);
            Console.ReadLine();
        }
    }
}
