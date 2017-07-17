using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace GeneralInformationSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool unsaveData = false;

        public bool UnsaveData
        {
            get { return unsaveData; }
            set { unsaveData = value; }
        }

        //当重写应用程序方法时,最好首先调用基类的实现.通常,基类的实现只是引发相应的应用程序事件
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UnsaveData = true;
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
            if(UnsaveData)
            {
                e.Cancel = true;
                MessageBoxResult result = MessageBox.Show("确定要退出应用程序吗?", "提示", MessageBoxButton.OKCancel);
                if(result==MessageBoxResult.Yes)
                {
                    //exit
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        //处理命令行参数
        private static void App_Startup(object sender,StartupEventArgs e)
        {
            if(e.Args.Length>0)
            {
                string arg = e.Args[0];
            }
        }
    }
}
