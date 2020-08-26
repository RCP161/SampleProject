using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Company.Styling.Icons;

namespace Company.Styling.Controls
{
    [ContentProperty(nameof(Icon))]
    public class InoIconBox : Control
    {

        static InoIconBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InoIconBox), new FrameworkPropertyMetadata(typeof(InoIconBox)));
        }

        public InoIconBox()
        {
            IconToFontString();
        }

        #region Dependancy Properties

        public IconName Icon
        {
            get { return (IconName)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(IconName), typeof(InoIconBox), new FrameworkPropertyMetadata(IconName.Dummy, OnIconPropertyChanged));


        public Geometry Data
        {
            get { return (Geometry)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =DependencyProperty.Register(nameof(Data), typeof(Geometry), typeof(InoIconBox), new PropertyMetadata(null));


        #endregion


        #region Events and Methods

        //Setting FontString based on IconAlias
        protected static void OnIconPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((InoIconBox)source).IconToFontString();
        }

        private void IconToFontString()
        {
            Data = IconDictionarry.Instance[Icon];
        }

        #endregion

    }
}
