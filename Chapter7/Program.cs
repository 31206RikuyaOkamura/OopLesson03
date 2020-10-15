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
        static Dictionary<char,int> dict = new Dictionary<char,int>();

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

            //7.1
            foreach (var ch in text.ToUpper())
            {
                int count = 0;
                if ('A' <= ch && ch <= 'Z')
                {
                    count++;
                    
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine("{0} : {1}", dict, item);
            }
        }

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
    }
}
