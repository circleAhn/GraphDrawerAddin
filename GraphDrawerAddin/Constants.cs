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

        public const int INITIAL_PRECISION = 50;
        public const int OVERCLOCKED_PRECISION = 299;
        public const int MAX_PRECISION = 199;
        public const int MIN_PRECISION = 10;
        public const float INITIAL_RATIO = 1f;
        public const float MAX_RATIO = 2f;
        public const float MIN_RATIO = 0.5f;
        public const string INITIAL_INTERVAL = "-2, 2";

        public const int INITIAL_CRITICAL_POINT_ACCURACY = 1;

        public const int INITIAL_SINGULAR_POINT_ACCURACY = 5;
        public const int OVERCLOCKED_SINGULAR_POINT_ACCURACY = 20;
        public const int MAX_SINGULAR_POINT_ACCURACY = 10;
        public const int MIN_SINGULAR_POINT_ACCURACY = 0;

        public const float DOT_RADIUS = 2f;

        

    }

    internal static class ErrorText
    {
        public const string ERROR = "Error: ";
        public static readonly string PRECISION = $"정밀도는 정수만 입력 가능합니다.\n허용범위: {Constants.MIN_PRECISION}-{Constants.MAX_PRECISION}";
        public static readonly string ZOOM_RATIO = $"확대/축소 비율은 숫자만 입력 가능합니다.\n허용범위: {Constants.MIN_RATIO * 100}-{Constants.MAX_RATIO * 100}";
        public static readonly string COORDINATE = "가로축 및 세로축 범위의 입력 양식은 \"숫자, 숫자\"의 (따옴표 제외) 형태입니다. \nex1) -2, 2\nex2) 4.35, 6.78\n";
        public static readonly string INTEGRAL_CONSTANT = "적분 상수는 숫자만 입력 가능합니다.";
        public static readonly string SINGULAR_POINT_ACCURACY = $"특이점 정확도는 숫자만 입력 가능합니다.\n허용범위: {Constants.MIN_SINGULAR_POINT_ACCURACY}-{Constants.MAX_SINGULAR_POINT_ACCURACY}";

        public static readonly string INTEGER = "숫자만 입력 가능합니다.";
        public static readonly string FLOAT = "실수만 입력 가능합니다.";
    }

    internal static class Settings
    {
        public static float XMin { get; set; }
        public static float XMax { get; set; }
        public static float YMin { get; set; }
        public static float YMax { get; set; }
        public static float DomainMin { get; set; }
        public static float DomainMax { get; set; }
        public static float YStretch { get; set; }
        public static bool IsDrawCoordinate { get; set; }
        public static bool IsYBoundaryAutoCheckBox { get; set; }
        public static float DotX { get; set; }
        public static float DotY { get; set; }
        public static bool IsContainsDotLineCheckBox { get; set; }
        public static bool IsAlsoDrawDotCheckBox { get; set; }
        public static float ZoomProp { get; set; }
        public static int Precision { get; set; }

        public static bool IsAccurateSingularPointCheckBox { get; set; }
        public static bool IsAccurateCriticalPointCheckBox { get; set; }
        public static int SingularPointAccuracy { get; set; }


        public static void Initialize(float[] x, float[] y, float[] domain, float zoomProp, int precision, bool isDrawCoordinate, bool isYBoundaryAutoCheckBox,
            bool isAccurateSingularPointCheckBox, bool isAccurateCriticalPointCheckBox, int singularPointAccuracy)
        {
            XMin = x[0];
            XMax = x[1];
            YMin = y[0];
            YMax = y[1];
            DomainMin = domain[0];
            DomainMax = domain[1];
            ZoomProp = zoomProp / 100;
            Precision = precision;
            YStretch = (YMax - YMin) / (XMax - XMin);
            IsDrawCoordinate = isDrawCoordinate;
            IsYBoundaryAutoCheckBox = isYBoundaryAutoCheckBox;
            IsAccurateSingularPointCheckBox = isAccurateSingularPointCheckBox;
            IsAccurateCriticalPointCheckBox = isAccurateCriticalPointCheckBox;
            SingularPointAccuracy = singularPointAccuracy;

        }

        public static void DotInitialize(float[] dot, bool isContainsDotLineCheckBox, bool isAlsoDrawDotCheckBox)
        {
            DotX = dot[0];
            DotY = dot[1];
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
