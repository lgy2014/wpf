using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GeneralInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AddChildren();
        }

        private void AddChildren()
        {
            //消息队列测试
            Button btnMessageQueue = new Button();
            btnMessageQueue.Content="create msg queue";
            btnMessageQueue.Click += btnMessageQueue_Click;
            wrapPanel.Children.Add(btnMessageQueue);

            Button btn2 = new Button();
            btn2.Content = "open exist queue";
            btn2.Click += btn2_Click;
            wrapPanel.Children.Add(btn2);

            Button btnCreate = new Button();
            btnCreate.Content = "create message queue installer";
            btnCreate.Click += btnCreate_Click;
            wrapPanel.Children.Add(btnCreate);
        }

        void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (MessageQueue.Exists(".\\Private$\\lgy"))
            {
                MessageQueue mq = new MessageQueue(".\\Private$\\lgy");
                mq.Send(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"),"label1");
                MessageBox.Show("send done");
            }
            else
            {
                MessageBox.Show("not exist");
            }
        }

        void btnMessageQueue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MessageQueue mq = MessageQueue.Create(@".\\Private$\\lgyqueue"))
                {
                    mq.Label = "demo queue";
                    MessageBox.Show("done");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\r\n"+ ex.StackTrace);
            }
        }

        private void btnUri_Click(object sender, RoutedEventArgs e)
        {
            UriTest t = new UriTest();
            t.Show();
        }

        private void btnElementBind_Click(object sender, RoutedEventArgs e)
        {
            ElementBind eb = new ElementBind();
            eb.Show();
        }

        private void btnFlowDocument_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument fd = new FlowDocument();
            fd.Show();
        }
    }
}
