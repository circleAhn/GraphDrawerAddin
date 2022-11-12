using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using static AngouriMath.MathS;
using static AngouriMath.Entity;
using AngouriMath;
using System.Diagnostics.Tracing;
using System.Reflection;

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

        public const int PLOT_NUM = 20;

    }

    internal class Drawer
    {
        public Variable x;
        public Entity expr;
        Func<double, float> f;

        public Drawer(Variable x, Entity expr) => Initializer(x, expr);
        public Drawer(Entity expr) => Initializer("x", expr);


        private void Initializer(Variable x, Entity expr)
        {
            this.x = x;
            this.expr = expr;
            f = expr.Compile<double, float>(x);
        }


        private float TranslateX(float x) => Constants.TRANSLATE_X + x;
        private float TranslateY(float y) => Constants.TRANSLATE_Y - y;

        private bool IsOutOfRange(float y) => Constants.COORDINATE_DOWN > y || y > Constants.COORDINATE_UP;


        public void DrawingCoordinate()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            PowerPoint.LineFormat xAxis = activeSlide.Shapes.AddLine(TranslateX(Constants.COORDINATE_LEFT), TranslateY(0), TranslateX(Constants.COORDINATE_RIGHT), TranslateX(0)).Line;
            xAxis.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
            xAxis.EndArrowheadStyle = Office.MsoArrowheadStyle.msoArrowheadStealth;
            xAxis.EndArrowheadLength = Office.MsoArrowheadLength.msoArrowheadLong;

            PowerPoint.LineFormat yAxis = activeSlide.Shapes.AddLine(TranslateX(0), TranslateY(Constants.COORDINATE_DOWN), TranslateX(0), TranslateY(Constants.COORDINATE_UP)).Line;
            yAxis.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
            yAxis.EndArrowheadStyle = Office.MsoArrowheadStyle.msoArrowheadStealth;
            yAxis.EndArrowheadLength = Office.MsoArrowheadLength.msoArrowheadLong;
        }

        public void Drawing()
        {
            DrawingCoordinate();

            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            PowerPoint.FreeformBuilder curveBuilder = null;
            PowerPoint.Shape curveShape = null;


            for (float X = Constants.COORDINATE_LEFT; X <= Constants.COORDINATE_RIGHT; X += (Constants.COORDINATE_RIGHT-Constants.COORDINATE_LEFT) / Constants.PLOT_NUM)
            {
                float Y = f(X / Constants.UNIT) * Constants.UNIT;

                if (IsOutOfRange(Y)) {

                    if (curveBuilder != null) {
                       
                        curveShape = curveBuilder.ConvertToShape();
                        curveShape.Line.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
                        curveShape.Line.Weight = 2f;
                        curveBuilder = null;
                    }

                    continue;
                }

                if (curveBuilder == null)
                {
                    curveBuilder = activeSlide.Shapes.BuildFreeform(Office.MsoEditingType.msoEditingCorner, TranslateX(X), TranslateY(f(X / Constants.UNIT) * Constants.UNIT));
                }
                else
                {
                    curveBuilder.AddNodes(Office.MsoSegmentType.msoSegmentCurve,
                                    Office.MsoEditingType.msoEditingAuto,
                                    TranslateX(X), TranslateY(f(X / Constants.UNIT) * Constants.UNIT));
                }
            }

            if (curveBuilder != null)
                curveShape = curveBuilder.ConvertToShape();
                curveShape.Line.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
                curveShape.Line.Weight = 2f;
        }

    }
}
