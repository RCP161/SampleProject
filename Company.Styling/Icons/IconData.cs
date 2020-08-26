using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Company.Styling.Icons
{
    internal static class IconData
    {
        internal static Geometry Plus = Geometry.Parse("M583 383q35 0 59.5 -24.5t24.5 -58.5t-24.5 -58.5t-59.5 -24.5l-166 3v-170q0 -34 -24.5 -58.5t-59.5 -24.5t-59 24.5t-24 58.5l3 170l-170 -3q-35 0 -59 24.5t-24 58.5t24 58.5t59 24.5h170l-3 167q0 34 24 58.5t59 24.5t59.5 -24.5t24.5 -58.5v-167h166z");

        internal static Geometry Minus = Geometry.Parse("M583 342q35 0 59.5 -25t24.5 -59t-24.5 -58.5t-59.5 -24.5h-500q-35 0 -59 24.5t-24 58.5q0 35 24.5 59.5t58.5 24.5h500z");
    }
}
