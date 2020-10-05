using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 5.1
            //Console.Write("１文字目：");
            //var str1 = Console.ReadLine();
            //Console.Write("２文字目：");
            //var str2 = Console.ReadLine();

            //if (String.Compare(str1,str2,true) == 0)
            //{
            //    Console.WriteLine("等しい");
            //}
            //else
            //{
            //    Console.WriteLine("等しくない");
            //}
            #endregion

            #region 5.2
            //Console.Write("\n文字列：");
            //var str = Console.ReadLine();
            //int num;
            //if(int.TryParse(str,out num))
            //{
            //    Console.WriteLine($"{num:#,#}");
            //}
            //else
            //{
            //    Console.WriteLine("数値文字列ではありません");
            //}
            #endregion

            #region 5.3
            ////5.3.1
            //var text = "Jackdaws Love my big sphinx of quartz";
            //int spaces = text.Count(c => c == ' ');
            //Console.WriteLine($"空白数：{spaces}");

            ////5.3.2
            //var replaced = text.Replace("big", "small");
            //Console.WriteLine(replaced);

            ////5.3.3
            //int count = text.Split(' ').Length;
            //Console.WriteLine($"単語数：{count}");

            ////5.3.4
            //var words = text.Split(' ').Where(s => s.Length <= 4);
            //foreach (var word in words)
            //{
            //    Console.WriteLine(word);
            //}

            ////5.3.5
            //var array = text.Split(' ').ToArray();
            //if (array.Length > 0)
            //{
            //    var text2 = new StringBuilder(array[0]);
            //    foreach (var word in array.Skip(1))
            //    {
            //        text2.Append(' ');
            //        text2.Append(word);
            //    }
            //    Console.WriteLine(text2);
            //}
            #endregion

            //5.4
            var text = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            foreach (var item in text.Split(';'))
            {
                var word = item.Split('=');
                Console.WriteLine($"{ToJapanese(word[0])}：{word[1]}");
            } 
        }

        static string ToJapanese(string key)
        {
            switch (key)
            {
                case "Novelist":
                    return "作家　";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                default:
                    return "      ";
            }
        }
    }
}
