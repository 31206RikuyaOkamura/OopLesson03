using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region 辞書登録プログラム
            //Console.WriteLine("**********************");
            //Console.WriteLine("* 辞書登録プログラム *");
            //Console.WriteLine("**********************");
            //while (true)
            //{
            //    Console.WriteLine("1.登録  2.内容を表示");
            //    Console.Write(">");
            //    var type = int.Parse(Console.ReadLine());

            //    if(type == 1)
            //    {
            //        DuplicateKey();
            //    }
            //    else if (type == 2)
            //    {
            //        // ディクショナリの内容を列挙
            //        foreach (var item in dict)
            //        {
            //            foreach (var term in item.Value)
            //            {
            //                Console.WriteLine("{0} : {1}", item.Key, term);
            //            }
            //        }
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("正しい値を入力してください。");
            //    }
            //}
            #endregion


            var text = "Cozy lummox gives smart squid who asks for job pen";
            Console.WriteLine("---7.1.1---");
            Exercise1_1(text);  //問題7.1.1

            Console.WriteLine("\n---7.1.2---");
            Exercise1_2(text);  //問題7.1.2

        }

        private static void Exercise1_2(string text)
        {
            var dict = new SortedDictionary<char, int>();

            foreach (var ch in text.ToUpper())
            {

                if ('A' <= ch && ch <= 'Z')
                {
                    if (dict.ContainsKey(ch))
                    {
                        dict[ch]++;
                    }
                    else
                    {
                        dict.Add(ch, 1);
                    }

                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        private static void Exercise1_1(string text)
        {
            var dict = new Dictionary<char, int>();

            foreach (var ch in text.ToUpper())
            {

                if ('A' <= ch && ch <= 'Z')
                {
                    if (dict.ContainsKey(ch))
                    {
                        dict[ch]++;
                    }
                    else
                    {
                        dict.Add(ch,1);
                    }

                }
            }
            foreach (var item in dict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        #region 辞書登録プログラム
        //public static void DuplicateKey()
        //{
        //    // ディクショナリに追加
        //    Console.Write("KEYを入力：");
        //    var key = Console.ReadLine();
        //    Console.Write("VALUEを入力：");
        //    var value = Console.ReadLine();
        //    if (dict.ContainsKey(key))
        //    {
        //        dict[key].Add(value);
        //    }
        //    else
        //    {
        //        dict[key] = new List<string> { value };
        //    }
        //    Console.WriteLine("登録しました！");
        //    Console.WriteLine();
        //}
        #endregion
    }
}
