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
            IconData iconData = new IconData();

            res.Add(IconAlias.Dummy, null);
            res.Add(IconAlias.AppLogo, iconData.AppLogo);
            res.Add(IconAlias.BasicLogo, iconData.BasicLogo);
            res.Add(IconAlias.SecurityLogo, iconData.SecurityLogo);
            res.Add(IconAlias.Home, iconData.Home);
            res.Add(IconAlias.Group, iconData.Group);
            res.Add(IconAlias.User, iconData.User);
            res.Add(IconAlias.Person, iconData.Person);
            return res;
        }
    }
}
