using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp
{
    class Config
    {
        //SMTPサーバー
        public string Smtp { get; set; }
        //自メールアドレス（送信元）
        public string MailAddress { get; set; }
        //パスワード
        public string PassWord { get; set; }
        //ポート番号
        public int Port { get; set; }
        //SSL設定
        public bool Ssl { get; set; }

        //初期設定用
        public void DefaultSet()
        {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
    }
}
