using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Company.Security.Core.Models;

namespace Company.Security.UI
{
    public class SecurityTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HomeTemplate { get; set; }
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                if(item is Home)
                    return HomeTemplate;
                if(item is User)
                    return UserTemplate;
                if(item is Group)
                    return GroupTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
