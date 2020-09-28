using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        { 
            #region 問題3.1
            //var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            ////3.1.1
            //var exits = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);
            //if (exits)
            //{
            //    Console.WriteLine("８か９で割り切れる数がある");
            //}
            //else
            //{
            //    Console.WriteLine("８か９で割り切れる数がない");
            //}

            //Console.WriteLine();
            ////3.1.2
            //numbers.ForEach(n => Console.WriteLine(n / 2.0));

            //Console.WriteLine();
            ////3.1.3
            //numbers.Where(n => n >= 50).ToList().ForEach(n => Console.WriteLine(n));

            //Console.WriteLine();
            ////3.1.4
            //numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);

            #endregion

            var names = new List<string>
            {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            #region 3.2.1
            //Console.WriteLine("\n---3.2.1---");
            //do
            //{
            //    Console.Write("都市名を入力。空行で終了：");
            //    var line = Console.ReadLine();
            //    if (string.IsNullOrEmpty(line))
            //    {
            //        break;
            //    }
            //    var index = names.FindIndex(x => x == line);
            //    Console.WriteLine(index);

            //} while (true);

            #endregion

            Console.WriteLine("\n---3.2.2----");
            var count = names.Count(x => x.Contains('o'));
            Console.WriteLine(count);

            Console.WriteLine("\n---3.2.3---");
            var selected = names.Where(x => x.Contains('o')).ToArray();
            foreach (var name in selected)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n---3.2.4---");
            var nameCounts = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
            foreach (var length in nameCounts)
            {
                Console.WriteLine(length);
            }
        }
    }
}
