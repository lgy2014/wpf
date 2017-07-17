using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace _02ControlTemplateBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            lb1.SelectionChanged += lb1_SelectionChanged;
        }

        void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Type type = (Type)lb1.SelectedItem;
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);
                control.Visibility = Visibility.Collapsed;
                grid.Children.Add(control);

                ControlTemplate template = control.Template;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);
                txt1.Text = sb.ToString();
                grid.Children.Remove(control);

            }
            catch (Exception ex)
            {
                txt1.Text = "<<Error generting template:"+ex.Message+">>";
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();

            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            //foreach (Type type in assembly.GetTypes)
            //{
            //    if(type.IsSubclassOf(controlType) && !type.IsAbstract &&type.IsPublic)
            //    {
            //        derivedTypes.Add(type);
            //    }
            //}
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsSubclassOf(controlType) && !types[i].IsAbstract && types[i].IsPublic)
                {
                    derivedTypes.Add(types[i]);
                }
            }
            derivedTypes.Sort(new TypeComparer());
            lb1.DisplayMemberPath = "Name";
            lb1.ItemsSource = derivedTypes;
        }
    }

    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }  
}
