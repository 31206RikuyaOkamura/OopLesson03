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
            #region Chapter6
            ////整数の例
            //var numbers = new List<int>
            //{
            //    19,17,15,24,12,25,14,20,12,28,19,30,24
            //};

            ////var strings = numbers.Distinct().Select(n => n.ToString("0000")).ToArray();
            ////foreach (var str in strings)
            ////{
            ////    Console.Write(str + " ");
            ////}
            //numbers.Distinct().Select(n => n.ToString("0000")).ToList().ForEach(s => Console.Write(s + "  "));
            //Console.WriteLine();


            //var sortedNumbers = numbers.OrderBy(n => n);
            //foreach (var nums in sortedNumbers)
            //{
            //    Console.Write(nums + "  ");
            //}
            //Console.WriteLine();


            ////文字列の例
            //var words = new List<string>
            //{
            //    "Microsoft","Apple","Google","Oracle","Facebook"
            //};

            //var lower = words.Select(name => name.ToLower());


            ////オブジェクトの例
            //var books = Books.GetBooks();

            ////タイトルリスト
            //var titles = books.Select(n => n.Title);

            //foreach (var title in titles)
            //{
            //    Console.WriteLine(title);
            //}

            ////ページ数の多い順に並べ替え(または金額の高い順)
            //Console.WriteLine("\nページ数の多い順に並べ替え");
            //var descBooks = books.OrderByDescending(b => b.Pages);
            //foreach (var descBook in descBooks)
            //{
            //    Console.WriteLine(descBook.Title + " " + descBook.Pages);
            //}

            #endregion

            //問題6.1
            var numbers = new int[]
            {
                5,10,17,9,3,21,10,40,21,3,35
            };

            //6.1.1
            Console.WriteLine($"最大値：{numbers.Max(n => n)}");

            //6.1.2
            Console.Write($"最後から2つの要素：");
            numbers.Skip(numbers.Length - 2).ToList().ForEach(n => Console.Write(n + "  "));

            //6.1.3
            Console.Write($"\n文字列に変換：");
            numbers.Select(n => n.ToString()).ToList().ForEach(n => Console.Write(n + "  "));

            //6.1.4
            Console.Write($"\n小さい順の３つ：");
            numbers.OrderBy(n => n).Take(3).ToList().ForEach(n => Console.Write(n + "  "));

            //6.1.5
            Console.WriteLine($"\n１０より大きい数がいくつあるか(重複排除)：{numbers.Distinct().Count(n => n > 10)}");


            //6.2
            var books = new List<Book>
            {
                new Book { Title = "C#プログラミングの新常識 C#", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 }
            };

            //6.2.1
            Console.WriteLine("---問１---");
            var book = books.Where(b => b.Title == "ワンダフル・C#ライフ");
            foreach (var item in book)
            {
                Console.WriteLine($"{item.Price} {item.Pages}");
            }

            //6.2.2
            Console.WriteLine("---問２---");
            var book2 = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine($"{book2}冊");

            //6.2.3
            Console.WriteLine("---問３---");
            var book3 = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine($"平均ページ数(C#を含む)：{book3}");

            //6.2.4
            Console.WriteLine("---問４---");
            var book4 = books.Where(b => b.Price >= 4000).First();
            if (book4 != null)
            {
                Console.WriteLine($"４０００円以上(最初のみ)：{book4.Title}");
            }

            //6.2.5
            Console.WriteLine("---問５---");
            Console.WriteLine($"４０００円未満の最大ページ数：{books.Where(b => b.Price < 4000).Max(b => b.Pages)}");

            //6.2.6
            Console.WriteLine("---問６---");
            var book6 = books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price);
            foreach (var item in book6)
            {
                Console.WriteLine($"{item.Title} {item.Price}");
            }

            //6.2.7
            Console.WriteLine("---問７---");
            var book7 = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            if (book7 != null)
            {
                foreach (var item in book7)
                {
                    Console.WriteLine(item.Title);
                }
            }


            var count = 0;

            foreach (var book8 in books.Where(b => b.Title.Contains("C#")))
            {
                for (int i = 0; i < book8.Title.Length - 1; i++)
                {
                    if ((book8.Title[i] == 'C'&& book8.Title[i + 1] == '#'))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"C#の数：{count}");
        }
    }
}