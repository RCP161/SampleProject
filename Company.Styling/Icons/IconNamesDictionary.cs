using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Company.Styling.Icons
{
    internal static class IconDictionarry
    {
        internal static Dictionary<IconName, Geometry> Instance { get; } = SetInstance();

        private static Dictionary<IconName, Geometry> SetInstance()
        {
            Dictionary<IconName, Geometry> res = new Dictionary<IconName, Geometry>();

            res.Add(IconName.Dummy, null);
            res.Add(IconName.Plus, IconData.Plus);
            res.Add(IconName.Minus, IconData.Minus);

            return res;
        }
    }
}
