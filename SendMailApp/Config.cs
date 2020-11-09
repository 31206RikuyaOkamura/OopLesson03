using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp
{
    public class Config
    {
        //単一のインスタンス
        private static Config instance = null;

        //インスタンスの取得
        public static Config GetInstance()
        {
            if (instance == null)
            {
                instance = new Config();
            }
            return instance;
        }

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

        //コンストラクタ（外部からnewできないようにする）
        private Config() { }

        //初期設定用
        public void DefaultSet()
        {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }

        //初期値取得
        public Config getDefaultStatus()
        {
            Config obj = new Config()
            {
                Smtp = "smtp.gmail.com",
                MailAddress = "ojsinfosys01@gmail.com",
                PassWord = "ojsInfosys2020",
                Port = 587,
                Ssl = true,
            };
            return obj;
        }

        //設定データ更新
        public bool UpdateStatus(string smtp,string mailAddress,string passWord,
            int port,bool ssl) //仮引数
        {
            this.Smtp = smtp;
            this.MailAddress = mailAddress;
            this.PassWord = passWord;
            this.Port = port;
            this.Ssl = ssl;

            return true;
        }

        //シリアル化
        public void Serialise()
        {
            Config cf = Config.GetInstance();
            using (var writer = XmlWriter.Create("Config.xml"))
            {
                var serializer = new XmlSerializer(cf.GetType());
                serializer.Serialize(writer, cf);
            }
        }

        //逆シリアル化
        public void DeSerialise()
        {
            using (var reader = XmlReader.Create("Config.xml"))
            {
                var serializer = new XmlSerializer(typeof(Config));
                var cf = serializer.Deserialize(reader) as Config;

                Smtp = cf.Smtp;
                MailAddress = cf.MailAddress;
                PassWord = cf.PassWord;
                Port = cf.Port;
                Ssl = cf.Ssl;
            }
        }
    }
}
