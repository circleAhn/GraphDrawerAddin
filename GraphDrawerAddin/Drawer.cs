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
using System.Text.RegularExpressions;
using System.Drawing.Text;
using System.Linq.Expressions;

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
            f = this.expr.Compile<double, float>(this.x);
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



        private List<Tuple<float, float>> NewtonMethod(List<Tuple<float, float>> XList, float beginX, float endX, bool reverse = false, int recursive = Constants.INITIAL_SINGULAR_POINT_ACCURACY)
        {
            if (recursive == 0)
                return XList;

            float midX = (beginX + endX) / 2;
            float midY = f(midX);

            if (!IsOutOfRange(midY))
            {
                XList.Add(new Tuple<float, float>(midX, midY));
            }

            if (IsOutOfRange(midY) ^ reverse)
            {
                NewtonMethod(XList, midX, endX, reverse, recursive - 1);
            }
            else
            {
                NewtonMethod(XList, beginX, midX, reverse, recursive - 1);
            }

            return XList;
        }


        private List<Tuple<float, float>> AddMiddle(List<Tuple<float, float>> XYList, float beginX, float endX, int recursive = Constants.INITIAL_CRITICAL_POINT_ACCURACY)
        {
            if (recursive == 0)
            {
                return XYList;
            }

            float beginY = f(beginX);
            float endY = f(endX);
            float m = (endY - beginY) / (endX - beginX);

            if (Math.Abs(m) < 0.5f)
            {
                float midX = (beginX + endX) / 2;
                float midY = f(midX);
                XYList.Add(new Tuple<float, float>(midX, midY));
                AddMiddle(XYList, beginX, midX, recursive - 1);
                AddMiddle(XYList, midX, endX, recursive - 1);
            }

            return XYList;
        }



        private void DrawingGraph()
        {
            PowerPoint.Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            PowerPoint.FreeformBuilder curveBuilder = null;

            float[] XArr = Enumerable.Range(0, Settings.Precision + 1).Select(it => (float)it / Settings.Precision * (Settings.XMax - Settings.XMin) + Settings.XMin).ToArray();
            List<List<Tuple<float, float>>> allTupleList = new List<List<Tuple<float, float>>>();


            List<Tuple<float, float>> tupleList = new List<Tuple<float, float>>();
            foreach (var (X, i) in XArr.Select((value, i) => (value, i)))
            {
                if (X < Settings.DomainMin)
                    continue;
                if (X > Settings.DomainMax)
                    continue;

                float Y = f(X);

                if (i < XArr.Length - 1)
                {
                    float XNext = XArr[i + 1];
                    float YNext = f(XNext);

                    if (IsOutOfRange(Y))
                    {
                        if (Settings.IsAccurateSingularPointCheckBox && !IsOutOfRange(YNext))
                        {
                            tupleList.AddRange(NewtonMethod(new List<Tuple<float, float>>(), X, XNext, recursive: Settings.SingularPointAccuracy));
                        }
                        else
                        {
                            allTupleList.Add(tupleList);
                            tupleList = new List<Tuple<float, float>>();
                        }
                    }
                    else
                    {
                        tupleList.Add(new Tuple<float, float>(X, Y));
                        if (Settings.IsAccurateCriticalPointCheckBox && !IsOutOfRange(YNext))
                        {
                            tupleList.AddRange(AddMiddle(new List<Tuple<float, float>>(), X, XNext));
                        }
                        if (Settings.IsAccurateSingularPointCheckBox && IsOutOfRange(YNext))
                        {
                            tupleList.AddRange(NewtonMethod(new List<Tuple<float, float>>(), X, XNext, true, Settings.SingularPointAccuracy));
                        }
                    }
                }
                else
                {
                    if (!IsOutOfRange(Y))
                    {
                        tupleList.Add(new Tuple<float, float>(X, Y));
                    }
                    allTupleList.Add(tupleList.OrderBy(it => it.Item1).ToList());
                }

            }
            


            foreach (List<Tuple<float, float>> tupleLs in allTupleList)
            {
                if (tupleLs.Count <= 1)
                    continue;

                foreach (var (value, i) in tupleLs.Select((value, i) => (value, i)))
                {
                    float X = value.Item1;
                    float Y = value.Item2;

                    if (i == 0)
                    {
                        curveBuilder = activeSlide.Shapes.TransformedBuildFreeform(X, Y);
                    } 
                    else
                    {
                        curveBuilder?.TransformedAddNodes(X, Y);
                    }
                }

                curveBuilder?.ConvertToShape().ApplyBoldStyleGraph();
            }

        }

    }
}
