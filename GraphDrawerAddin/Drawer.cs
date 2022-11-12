using System;
using static AngouriMath.Entity;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace GraphDrawerAddin
{

    internal class Drawer
    {
        public Variable x;
        public Entity expr;
        private Func<double, float> f;

        private float F(double x) => f(x / Constants.UNIT) * Constants.UNIT;


        public Drawer(Variable x, Entity expr) => Initializer(x, expr);
        public Drawer(Entity expr) => Initializer("x", expr);


        private void Initializer(Variable x, Entity expr)
        {
            this.x = x;
            this.expr = expr;
            f = expr.Compile<double, float>(x);
        }

        private bool IsOutOfRange(float y) => Constants.COORDINATE_DOWN > y || y > Constants.COORDINATE_UP;


        public void Drawing()
        {
            DrawingCoordinate();
            DrawingGraph();
        }


        private void DrawingCoordinate()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;

            // x-axis
            activeSlide.Shapes
                .TranslatedAddLine(Constants.COORDINATE_LEFT, 0, Constants.COORDINATE_RIGHT, 0)
                .Line.ApplyArrowStyleLine();

            // y-axis
            activeSlide.Shapes
                .TranslatedAddLine(0, Constants.COORDINATE_DOWN, 0, Constants.COORDINATE_UP)
                .Line.ApplyArrowStyleLine();
        }

        private void DrawingGraph()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            PowerPoint.FreeformBuilder curveBuilder = null;

            for (float X = Constants.COORDINATE_LEFT; X <= Constants.COORDINATE_RIGHT; X += (Constants.COORDINATE_RIGHT - Constants.COORDINATE_LEFT) / Constants.PLOT_NUM)
            {
                float Y = F(X);

                if (IsOutOfRange(Y))
                {
                    curveBuilder?.ConvertToShape().ApplyBoldStyleGraph();
                    curveBuilder = curveBuilder != null ? null : curveBuilder;
                    continue;
                }

                if (curveBuilder == null)
                {
                    curveBuilder = activeSlide.Shapes.TranslatedBuildFreeform(X, Y);
                }

                curveBuilder?.TranslatedAddNodes(X, Y);
            }

            curveBuilder?.ConvertToShape().ApplyBoldStyleGraph();
        }


    }
}
