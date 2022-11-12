using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDrawerAddin
{
    internal static class Constants
    {
        public const float COORDINATE_UP = 100f;
        public const float COORDINATE_DOWN = -100f;
        public const float COORDINATE_LEFT = -100f;
        public const float COORDINATE_RIGHT = 100f;
        public const float TRANSLATE_X = 200f;
        public const float TRANSLATE_Y = 200f;
        public const float UNIT = 50f;

        public const int PLOT_NUM = 50;

    }

    internal static class Style
    {
        public const float LINE_BOLD = 2.0f;
        public const float LINE_REGULAR = 1.0f;
    }

    internal static class Color
    {
        public static readonly int BLACK = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
    }
}
