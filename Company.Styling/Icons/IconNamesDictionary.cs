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
            res.Add(IconAlias.AppLogo, IconData.AppLogo);
            res.Add(IconAlias.BasicLogo, IconData.BasicLogo);
            res.Add(IconAlias.SecurityLogo, IconData.SecurityLogo);
            res.Add(IconAlias.Home, IconData.Home);
            res.Add(IconAlias.Group, IconData.Group);
            res.Add(IconAlias.User, IconData.User);
            res.Add(IconAlias.Person, IconData.Person);
            return res;
        }
    }
}
