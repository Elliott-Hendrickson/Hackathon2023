using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuckAPP
{
    internal static class GetSize
    {
        public static Point FindUserScreenSize ( )
        {
            var x = System.Windows.Forms.Screen.GetBounds(new Point(0,0));
            return new Point(x.Width-626, x.Height-352);
        }
    }
}
