using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using AngouriMath;
using static AngouriMath.MathS;
using static AngouriMath.Entity;

namespace GraphDrawerAddin
{

    internal class Drawer
    {
        public Variable x;
        public Entity expr;
        private Func<double, float> f;


        public Drawer(Variable x, Entity expr) => Initializer(x, expr);
        public Drawer(Entity expr) => Initializer("x", expr);


        private void Initializer(Variable x, Entity expr)
        {
            this.x = x;
            this.expr = expr;
            f = expr.Compile<double, float>(x);
        }

        private bool IsOutOfRange(float y) => Settings.YMin > y || y > Settings.YMax || float.IsNaN(y);


        public void Drawing()
        {
            if (Settings.IsDrawCoordinate)
                DrawingCoordinate();
            DrawingGraph();
        }

        public void Ploting()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            if ((Settings.XMin <= Settings.DotX) && (Settings.DotX <= Settings.XMax))
                if ((Settings.YMin <= Settings.DotY) && (Settings.DotY <= Settings.YMax))
                {
                    activeSlide.Shapes
                        .TransformedAddDot(Settings.DotX, Settings.DotY)
                        .ApplyBoldStyleDot();

                    if (Settings.IsContainsDotLineCheckBox)
                    {
                        activeSlide.Shapes
                            .TransformedAddLine(Settings.DotX, Settings.DotY, Settings.DotX, 0)
                            .Line.ApplyDashedStyleLine();

                            activeSlide.Shapes
                                .TransformedAddLine(Settings.DotX, Settings.DotY, 0, Settings.DotY)
                                .Line.ApplyDashedStyleLine();
                    }

                }
        }

        public void DrawingTangentLine()
        {
            if (Math.Abs(f(Settings.DotX) - Settings.DotY) < 0.001f)
            {
                float m = expr.Differentiate(x).Compile<double, float>(x)(Settings.DotX);
                float y = f(Settings.DotX);
                Entity tangent = m.ToString() + " * (x - " + Settings.DotX.ToString() + " ) + " + y.ToString();
                f = tangent.Compile<double, float>(x);
                Drawing();
            }
            else
            {
                throw new Exception("표시된 점이 함수의 접점에 가까이 있지 않은 것 같습니다.");
            }
            
        }


        private void DrawingCoordinate()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            // x-axis
            if (Settings.XMin * Settings.XMax <= 0)
            {
                activeSlide.Shapes
                    .TransformedAddLine(Settings.XMin, 0, Settings.XMax, 0)
                    .Line.ApplyArrowStyleLine();

                activeSlide.Shapes.TransformedAddTextbox(Settings.XMax, 0, 
                    Constants.TEXTBOX_WIDTH_PXL, Constants.TEXTBOX_HEIGHT_PXL, 
                    -20, -7)
                    .ApplyEquationText("x");
            }
            // y-axis
            if (Settings.YMin * Settings.YMax <= 0)
            {
                activeSlide.Shapes
                    .TransformedAddLine(0, Settings.YMin, 0, Settings.YMax)
                    .Line.ApplyArrowStyleLine();

                activeSlide.Shapes.TransformedAddTextbox(0, Settings.YMax, 
                    Constants.TEXTBOX_WIDTH_PXL, Constants.TEXTBOX_HEIGHT_PXL, 
                    -20, -10)
                    .ApplyEquationText("y");
            }

            if (Settings.XMin * Settings.XMax <= 0)
                if (Settings.YMin * Settings.YMax <= 0)
                {
                    activeSlide.Shapes.TransformedAddTextbox(0, 0,
                        Constants.TEXTBOX_WIDTH_PXL, Constants.TEXTBOX_HEIGHT_PXL,
                        -23, -5)
                        .ApplyEquationText("O", isItalic: false);
                }

        }

        private void DrawingGraph()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            PowerPoint.FreeformBuilder curveBuilder = null;

            float[] XArr = Enumerable.Range(0, Settings.Precision + 1).Select(it => (float)it / Settings.Precision * (Settings.XMax - Settings.XMin) + Settings.XMin).ToArray();

            //for (float X = Settings.XMin; X <= Settings.XMax; X += (Settings.XMax - Settings.XMin) / Settings.Precision)
            foreach(float X in XArr)
            {
                float Y = f(X);

                if (IsOutOfRange(Y))
                {
                    curveBuilder?.ConvertToShape().ApplyBoldStyleGraph();
                    curveBuilder = null; //curveBuilder != null ? null : curveBuilder;
                    continue;
                }

                curveBuilder?.TransformedAddNodes(X, Y);
                if (curveBuilder == null)
                {
                    curveBuilder = activeSlide.Shapes.TransformedBuildFreeform(X, Y);
                }

            }

            curveBuilder?.ConvertToShape().ApplyBoldStyleGraph();
        }


    }
}
