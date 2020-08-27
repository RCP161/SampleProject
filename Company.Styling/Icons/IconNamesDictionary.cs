using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Company.Base.Core;

namespace Company.Styling.Icons
{
    internal static class IconDictionarry
    {
        internal static Dictionary<IconAlias, Geometry> Instance { get; } = SetInstance();

        private static Dictionary<IconAlias, Geometry> SetInstance()
        {
            Dictionary<IconAlias, Geometry> res = new Dictionary<IconAlias, Geometry>();

            res.Add(IconAlias.Dummy, null);
            res.Add(IconAlias.AppLogo, IconData.Plus);
            res.Add(IconAlias.BasicLogo, IconData.Minus);
            res.Add(IconAlias.SecurityLogo, IconData.Minus);

            return res;
        }
    }
}
