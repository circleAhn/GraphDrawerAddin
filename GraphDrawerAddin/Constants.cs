using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDrawerAddin
{
    internal static class Constants
    {
        public const float COORDINATE_WIDTH_PXL = 200f;
        public const float COORDINATE_HEIGHT_PXL = 200f;
        public const float TRANSLATE_X_PXL = 100f;
        public const float TRANSLATE_Y_PXL = 400f;

        public const float TEXTBOX_WIDTH_PXL = 20f;
        public const float TEXTBOX_HEIGHT_PXL = 20f;


        public const int MAX_PRECISION = 200;
        public const int MIN_PRECISION = 10;
        public const float MAX_RATIO = 2f;
        public const float MIN_RATIO = 0.5f;

        public const float DOT_RADIUS = 2f;

        

    }

    internal static class Settings
    {
        public static float XMin { get; set; }
        public static float XMax { get; set; }

        public static float YMin { get; set; }
        public static float YMax { get; set; }

        public static float YStretch { get; set; }

        public static bool IsDrawCoordinate { get; set; }
        public static bool IsYBoundaryAutoCheckBox { get; set; }

        public static float DotX { get; set; }
        public static float DotY { get; set; }

        public static bool IsContainsDotLineCheckBox { get; set; }

        public static bool IsAlsoDrawDotCheckBox { get; set; }



        private static float zoomProp;
        public static float ZoomProp
        {
            get
            {
                return zoomProp;
            }
            set
            {
                zoomProp = Math.Max(Constants.MIN_RATIO, Math.Min(Constants.MAX_RATIO, value));
            }
        }

        private static int precision;
        public static int Precision
        {
            get
            {
                return precision;
            }
            set
            {
                precision = Math.Max(Constants.MIN_PRECISION, Math.Min(Constants.MAX_PRECISION, value));
            }
        }


        public static void Initialize(float xMin, float xMax, float yMin, float yMax, float zoomProp, int precision, bool isDrawCoordinate, bool isYBoundaryAutoCheckBox)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            ZoomProp = zoomProp / 100;
            Precision = precision;
            YStretch = (yMax - yMin) / (XMax - XMin);
            IsDrawCoordinate= isDrawCoordinate;
            IsYBoundaryAutoCheckBox = isYBoundaryAutoCheckBox;
        }

        public static void DotInitialize(float dotX, float dotY, bool isContainsDotLineCheckBox, bool isAlsoDrawDotCheckBox)
        {
            DotX = dotX;
            DotY = dotY;
            IsContainsDotLineCheckBox = isContainsDotLineCheckBox;
            IsAlsoDrawDotCheckBox = isAlsoDrawDotCheckBox;
        }
    }

    internal static class Style
    {
        public const float LINE_BOLD = 2.0f;
        public const float LINE_REGULAR = 1.0f;

        public const string FONT_NAME = "LM Roman 10";
    }

    internal static class Color
    {
        public static readonly int BLACK = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
    }
}
