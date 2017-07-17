using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GeneralInformationSystem
{
    /// <summary>
    /// Interaction logic for UriTest.xaml
    /// </summary>
    public partial class UriTest : Window
    {
        public UriTest()
        {
            InitializeComponent();

            img.Source = new BitmapImage(new Uri("Image/d1.jpg", UriKind.Relative));//第二个参数(UriKind.Relative)没有写时,居然报错了.


            img.Source = new BitmapImage(new Uri("pack://application:,,,/Image/d2.jpg"));//这一种写法和上面的效果一样,这样的路径语法来自xps标准.这里是把一个uri嵌入到了另一个uri中,三个逗号其实是三个转义的斜杠.即pack URI是以application:///开头的.此语法还可以检索到嵌入到另一个库中的资源

            //嵌入外部程序集资源,需要引用该程序集
            img.Source = new BitmapImage(new Uri("pack://application:,,,/ImageLibrary;component/Image/d6.jpg"));
            //另一种写法,这种写法没有正确加载资源,可以带上版本号和公钥标记使用;分割
            //img.Source = new BitmapImage(new Uri("ImageLibrary;component/Image/d5.jpg",UriKind.Relative));

        }
    }
}
