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

namespace _01test
{
    /// <summary>
    /// Interaction logic for _02Combox.xaml
    /// </summary>
    public partial class _02Combox : Window
    {
        public _02Combox()
        {
            InitializeComponent();

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("001", "001");
            d.Add("002", "002");
            d.Add("003", "003");
            d.Add("004", "004");

            cb1.IsEditable = true;
            cb1.DisplayMemberPath = "Key";
            cb1.SelectedValuePath = "Value";
            cb1.ItemsSource = d;

            cb1.TextInput += cb1_TextInput;
        }

        void cb1_TextInput(object sender, TextCompositionEventArgs e)
        {
            if(cb1.IsDropDownOpen==false)
            {
                cb1.IsDropDownOpen = true;
            }
            cb1.IsDropDownOpen = true;
        }

        private void cb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cb1.IsDropDownOpen == false)
            {
                cb1.IsDropDownOpen = true;
            }
        }
    }
}
