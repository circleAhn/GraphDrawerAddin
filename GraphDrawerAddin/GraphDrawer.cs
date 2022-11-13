using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

using AngouriMath;
using static AngouriMath.MathS;
using static AngouriMath.Entity;
using System.Xml.Schema;
using Microsoft.Office.Core;

namespace GraphDrawerAddin
{
    public partial class GraphDrawer
    {
        private void GraphDrawer_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void GraphGeneratorButton_Click(object sender, RibbonControlEventArgs e)
        {
            Initialize();

            try
            {
                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Drawer drawer = new Drawer(x, expr);
                drawer.Drawing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }

        }

        private void Initialize()
        {
            try
            {
                float[] XAxisBoundary = BoundaryParser(xAxisBoundary.Text);
                float[] YAxisBoundary = BoundaryParser(yAxisBoundary.Text);
                float ZoomProp = Convert.ToSingle(zoomSize.Text);
                int Precision = Convert.ToInt32(precision.Text);
                bool IsDrawCoordinate = isDrawCoordinateCheckBox.Checked;
                bool IsYBoundaryAutoCheckBox = isYBoundaryAutoCheckBox.Checked;

                if (ZoomProp > Constants.MAX_RATIO * 100)
                {
                    zoomSize.Text = (Constants.MAX_RATIO * 100).ToString();
                }
                if (ZoomProp < Constants.MIN_RATIO * 100)
                {
                    zoomSize.Text = (Constants.MIN_RATIO * 100).ToString();
                }
                if (IsYBoundaryAutoCheckBox)
                {
                    yAxisBoundary.Text = xAxisBoundary.Text;
                    YAxisBoundary = BoundaryParser(yAxisBoundary.Text);
                }

                Settings.Initialize(
                    xMin: XAxisBoundary[0],
                    xMax: XAxisBoundary[1],
                    yMin: YAxisBoundary[0],
                    yMax: YAxisBoundary[1],
                    zoomProp: ZoomProp,
                    precision: Precision,
                    isDrawCoordinate: IsDrawCoordinate,
                    isYBoundaryAutoCheckBox: IsYBoundaryAutoCheckBox);

            }
            catch (Exception ex)
            {
                MessageBox.Show("그래프 옵션의 입력값 오류입니다. 그래프 옵션에서 입력값을 제대로 입력했는지 확인해주세요." +
                    "\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }

        private float[] BoundaryParser(string str)
        {
            try
            {
                float[] boundary = str.ToString().Split(',')
                    .Select(it => Convert.ToSingle(it.Trim())).ToArray();
                return new float[] { boundary[0], boundary[1] };
            }
            catch
            {
                throw new Exception("가로축 및 세로축 범위의 입력 양식은 \"실수, 실수\" (따옴표 제외) 형태입니다. \nex1) -2, 2\nex2) 4.35, 6.78\n");
            }
        }

        private void DrawDerivative_Click(object sender, RibbonControlEventArgs e)
        {
            Initialize();

            try
            {
                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Drawer drawer = new Drawer(x, expr.Differentiate(x));
                drawer.Drawing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }

        private void DrawIntegral_Click(object sender, RibbonControlEventArgs e)
        {
            Initialize();

            try
            {

                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Entity constant = Convert.ToSingle(integralConstant.Text).ToString();
                Drawer drawer = new Drawer(x, expr.Integrate(x) + constant);
                drawer.Drawing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }

        private void InstallFonts_Click(object sender, RibbonControlEventArgs e)
        {
            FontSettings.InstallFonts();
        }

        private void yBoundaryAutoCheckBox_Click(object sender, RibbonControlEventArgs e)
        {
            if (isYBoundaryAutoCheckBox.Checked)
            {
                yAxisBoundary.Enabled = false;
                yAxisBoundary.Text = xAxisBoundary.Text;
            }
            else
            {
                yAxisBoundary.Enabled = true;
            }
        }

        private void DrawDot_Click(object sender, RibbonControlEventArgs e)
        {
            Initialize();

            try
            {
                float[] DotCoordinate = BoundaryParser(dotCoordinate.Text);
                bool IsContainsDotLineCheckBox = isContainsDotLineCheckBox.Checked;
                bool IsAlsoDrawDotCheckBox = isAlsoDrawDotCheckBox.Checked;

                Settings.DotInitialize(
                        dotX: DotCoordinate[0],
                        dotY: DotCoordinate[1],
                        isContainsDotLineCheckBox: IsContainsDotLineCheckBox,
                        isAlsoDrawDotCheckBox: IsAlsoDrawDotCheckBox);

                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Drawer drawer = new Drawer(x, expr);
                drawer.Ploting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }

        private void DrawTangent_Click(object sender, RibbonControlEventArgs e)
        {
            Initialize();

            try
            {
                float[] DotCoordinate = BoundaryParser(dotCoordinate.Text);
                bool IsContainsDotLineCheckBox = isContainsDotLineCheckBox.Checked;
                bool IsAlsoDrawDotCheckBox = isAlsoDrawDotCheckBox.Checked;

                Settings.DotInitialize(
                        dotX: DotCoordinate[0],
                        dotY: DotCoordinate[1],
                        isContainsDotLineCheckBox: IsContainsDotLineCheckBox,
                        isAlsoDrawDotCheckBox: IsAlsoDrawDotCheckBox);

                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Drawer drawer = new Drawer(x, expr);
                drawer.DrawingTangentLine();

                if (IsAlsoDrawDotCheckBox)
                    drawer.Ploting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }
    }
}
