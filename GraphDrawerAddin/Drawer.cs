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


        private void DrawingCoordinate()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            // x-axis
            if (Settings.XMin * Settings.XMax <= 0)
            {
                activeSlide.Shapes
                    .TransformedAddLine(Settings.XMin, 0, Settings.XMax, 0)
                    .Line.ApplyArrowStyleLine();
            }
            // y-axis
            if (Settings.YMin * Settings.YMax <= 0)
            {
                activeSlide.Shapes
                    .TransformedAddLine(0, Settings.YMin, 0, Settings.YMax)
                    .Line.ApplyArrowStyleLine();
            }
        }

        private void DrawingGraph()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            PowerPoint.FreeformBuilder curveBuilder = null;

            for (float X = Settings.XMin; X <= Settings.XMax; X += (Settings.XMax - Settings.XMin) / Settings.Precision)
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
