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
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4 };
            Console.WriteLine($"平均値：{numbers.Average()}");
            Console.WriteLine($"合計値：{numbers.Sum()}");
            Console.WriteLine($"最小値：{numbers.Where(x => x >= 0).Min()}");
            Console.WriteLine($"最大値：{numbers.Max()}");

            bool exists = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(3);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }



            Console.WriteLine();
            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格：{books.Average(b => b.Price)}");
            Console.WriteLine($"本の合計価格：{books.Sum(b => b.Price)}");
            Console.WriteLine($"本のページが最大：{books.Max(b => b.Pages)}");
            Console.WriteLine($"高価な本：{books.Max(b => b.Price)}");
            Console.WriteLine($"タイトルに「物語」がある冊数：{books.Count(b => b.Title.Contains("物語"))}");

            //600ページを超える書籍があるか
            Console.Write("600ページを超える書籍があるか？：");
            Console.WriteLine(books.Any(n => n.Pages > 600) ? "ある" : "ない");

            //全てが200ページ以上の書籍か？
            Console.Write("全てが200ページ以上の書籍か？：");
            Console.WriteLine(books.All(n => n.Pages >= 200) ? "全てが200ページ以上" : "全てが200ページ以上ではない");


            //400ページを超える本は何冊目か？
            Console.Write("400ページを超える本は何冊目か？：");
            var book = books.FirstOrDefault(n => n.Pages > 400);
            int i;
            for (i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Contains(book.Title))
                {
                    break;
                }
            }
            Console.WriteLine($"400ページを超える本は{i + 1}冊目");
            //Console.WriteLine($"{ books.FindIndex(n => n.Pages > 400) + 1}冊目");

            //本の値段が400円以上のものを3冊表示
            Console.WriteLine("\n本の値段が400円以上のものを3冊表示");
            var resultBooks = books.Where(n => n.Price >= 400).Take(3);
            foreach (var resultBook in resultBooks)
            {
                Console.WriteLine(resultBook.Title);
            }
        }
    }
}
