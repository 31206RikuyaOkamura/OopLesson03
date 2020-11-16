using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        SmtpClient sc = new SmtpClient();

        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("送信はキャンセルされました。");
            }
            else
            {
                MessageBox.Show(e.Error?.Message ?? "送信完了！");
            }
        }

        //メール送信処理
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Config cf = Config.GetInstance();
                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text);

                msg.Subject = tbTirle.Text; //件名
                msg.Body = tbBody.Text; //本文

                if (tbCc.Text != "")
                {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "")
                {
                    msg.Bcc.Add(tbBcc.Text);
                }

                foreach (var item in rbFile.Items)
                {
                    var attach = new System.Net.Mail.Attachment(item.ToString());
                    msg.Attachments.Add(attach);
                }

                sc.Host = cf.Smtp; //SMTPサーバーの設定
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

                if (tbTirle.Text == "" || tbBody.Text == "")
                {
                    if (MessageBox.Show("件名または本文が入力されていません\n送信しますか？", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        sc.SendMailAsync(msg);
                    }
                }
                else
                {
                    //sc.Send(msg); //送信
                    sc.SendMailAsync(msg);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //送信キャンセル処理
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            sc.SendAsyncCancel();
        }

        //設定画面表示
        private void btConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindowShow();
        }

        private static void ConfigWindowShow()
        {
            //設定画面のインスタンスを生成
            ConfigWindow configWindow = new ConfigWindow();
            //表示
            configWindow.ShowDialog();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialise();
            }
            catch (System.IO.FileNotFoundException)
            {
                ConfigWindowShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //メインウィンドウが閉じるタイミングで呼び出される
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Config.GetInstance().Serialise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addFile_Click(object sender, RoutedEventArgs e)
        {
            //オープンファイルダイアログを生成する
            var op = new OpenFileDialog();

            if (op.ShowDialog() == true)
            {
                //「開く」ボタンが選択された時の処理
                rbFile.Items.Add(op.FileName);
            }
        }

        private void deleteFile_Click(object sender, RoutedEventArgs e)
        {
            rbFile.Items.Clear();
        }
    }
}
