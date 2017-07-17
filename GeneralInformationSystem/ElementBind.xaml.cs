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
    /// Interaction logic for ElementBind.xaml
    /// </summary>
    public partial class ElementBind : Window
    {
        public ElementBind()
        {
            InitializeComponent();


            #region 使用代码创建绑定
            Binding binding = new Binding();
            binding.Source = sliderFontSize;
            binding.Path = new PropertyPath("Value");
            binding.Mode = BindingMode.TwoWay;
            binding.Delay = 500;//绑定延迟
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;//更改绑定更新方式
            /*
             * Default:绑定目标属性的默认 UpdateSourceTrigger 值。 大多数依赖项属性的默认值都为 PropertyChanged，而 Text 属性的默认值为 LostFocus。 
确定依赖项属性的默认 UpdateSourceTrigger 值的编程方法是使用 GetMetadata 来获取属性的属性元数据，然后检查 DefaultUpdateSourceTrigger 属性的值。

             * Explicit:仅在调用 UpdateSource 方法时更新绑定源。
             * 
             * LostFocus:当绑定目标元素失去焦点时，更新绑定源。
             * 
             * PropertyChanged:当绑定目标属性更改时，立即更新绑定源。
             */

            txtSize.SetBinding(TextBox.TextProperty, binding); 
            #endregion

            /*绑定模式:
             
             * Default:使用绑定目标的默认 Mode 值。 每个依赖项属性的默认值都不同。 一般情况下，用户可编辑控件属性（例如文本框和复选框的属性）默认为双向绑定，而多数其他属性默认为单向绑定。 确定依赖项属性绑定在默认情况下是单向还是双向的编程方法是：使用 GetMetadata 获取属性的属性元数据，然后检查 BindsTwoWayByDefault 属性的布尔值。 
             * 
             * OneTime:当应用程序启动或数据上下文更改时，更新绑定目标。 此绑定类型适用于以下情况：使用当前状态的快照适合使用的或数据状态实际为静态的数据。 如果要从源属性初始化具有某个值的目标属性，并且事先不知道数据上下文，则也可以使用此绑定类型。 此绑定类型实质上是 OneWay 绑定的简化形式，在源值不更改的情况下可以提供更好的性能。 
             * 
             * OneWay:当绑定源（源）更改时，更新绑定目标（目标）属性。 此绑定类型适用于绑定的控件为隐式只读控件的情况。 例如，可以绑定到如股市代号之类的源。 或者，可能目标属性没有用于进行更改（例如表的数据绑定背景色）的控件接口。 如果无需监视目标属性的更改，则使用 OneWay 绑定模式可避免 TwoWay 绑定模式的系统开销。 
             * 
             * OneWayToSource:当目标属性更改时更新源属性。
             * 
             * TwoWay:导致对源属性或目标属性的更改可自动更新对方。 此绑定类型适用于可编辑窗体或其他完全交互式 UI 方案。 
             */

            #region 清除绑定
            //BindingOperations.ClearAllBindings(labelSimple);
            //BindingOperations.ClearBinding(labelSimple, TextBlock.TextProperty);
            //它们均调用ClearValue(),该方法简单地移除属性的本地值,这里是数据绑定表达式
            
            #endregion

            #region 检索绑定
            Binding binding2 = BindingOperations.GetBinding(labelSimple, TextBlock.TextProperty);

            BindingExpression expression = BindingOperations.GetBindingExpression(labelSimple, TextBlock.FontSizeProperty);
            Slider slider = (Slider)expression.ResolvedSource;
            string val = slider.FontSize.ToString();
            //MessageBox.Show(val);
            #endregion
        }
    }
}
