using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        //初期値ボタン
        private void btDefalt_Click(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            //Config defaultData = cf.getDefaultStatus();

            tbSmto.Text = cf.Smtp;
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPrto.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            CbSsl.IsChecked = cf.Ssl;
        }

        //適用（更新）
        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private bool update()
        {
            if (tbSmto.Text == "" || tbUserName.Text == "" || tbSender.Text == "" || tbPassWord.Password == "" || tbPrto.Text == "")
            {
                MessageBox.Show("正しい値を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                //更新処理を呼び出す
                Config.GetInstance().UpdateStatus(
                    tbSmto.Text,
                    tbUserName.Text,
                    tbPassWord.Password,
                    int.Parse(tbPrto.Text),
                    CbSsl.IsChecked ?? false);
                return true;
            }
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (update())
            {
                this.Close();
            }
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (updateCheck())
            {
                if (MessageBox.Show("変更が反映されていません\n移動しますか？", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private bool updateCheck()
        {
            Config cf = Config.GetInstance();
            if (tbSmto.Text != cf.Smtp || tbUserName.Text != cf.MailAddress || tbSender.Text != cf.MailAddress || tbPrto.Text != cf.Port.ToString() || tbPassWord.Password != cf.PassWord || CbSsl.IsChecked != cf.Ssl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config cf = Config.GetInstance();

            tbSmto.Text = cf.Smtp;
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPrto.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            CbSsl.IsChecked = cf.Ssl;
        }
    }
}
