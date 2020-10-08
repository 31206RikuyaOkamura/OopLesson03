using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            //整数の例
            var numbers = new List<int>
            {
                19,17,15,24,12,25,14,20,12,28,19,30,24
            };

            //var strings = numbers.Distinct().Select(n => n.ToString("0000")).ToArray();
            //foreach (var str in strings)
            //{
            //    Console.Write(str + " ");
            //}
            numbers.Distinct().Select(n => n.ToString("0000")).ToList().ForEach(s => Console.Write(s + "  "));
            Console.WriteLine();


            var sortedNumbers = numbers.OrderBy(n => n);
            foreach (var nums in sortedNumbers)
            {
                Console.Write(nums + "  ");
            }
            Console.WriteLine();


            //文字列の例
            var words = new List<string>
            {
                "Microsoft","Apple","Google","Oracle","Facebook"
            };

            var lower = words.Select(name => name.ToLower());


            //オブジェクトの例
            var books = Books.GetBooks();

            //タイトルリスト
            var titles = books.Select(n => n.Title);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            //ページ数の多い順に並べ替え(または金額の高い順)
            Console.WriteLine("\nページ数の多い順に並べ替え");
            var descBooks = books.OrderByDescending(b => b.Pages);
            foreach (var descBook in descBooks)
            {
                Console.WriteLine(descBook.Title + " " + descBook.Pages);
            }

        }
    }
}
