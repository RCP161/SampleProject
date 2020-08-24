﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Company2.AppName
{
    public class ModulTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BasicTemplate { get; set; }
        public DataTemplate SecurityTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                if(item is Company.Basic.Core.Models.Home)
                    return BasicTemplate;
                if(item is Company.Security.Core.Models.Home)
                    return SecurityTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
