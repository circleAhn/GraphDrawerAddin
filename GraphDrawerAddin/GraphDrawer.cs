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
                Entity expr = LogToLn(expressionEditBox.Text);
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
            Settings.Initialize(
                StringToFloatArray(xAxisBoundary.Text),
                StringToFloatArray(yAxisBoundary.Text),
                StringToFloatArray(domainBoundary.Text),
                Convert.ToSingle(zoomSize.Text),
                Convert.ToInt32(precision.Text),
                isDrawCoordinateCheckBox.Checked,
                isYBoundaryAutoCheckBox.Checked,
                isAccurateSingularPointCheckBox.Checked,
                isAccurateCriticalPointCheckBox.Checked,
                Convert.ToInt32(singularPointAccuracy.Text));
        }

        private void DotInitialize()
        {
            Settings.DotInitialize(
                    dot: StringToFloatArray(dotCoordinate.Text),
                    isContainsDotLineCheckBox: isContainsDotLineCheckBox.Checked,
                    isAlsoDrawDotCheckBox: isAlsoDrawDotCheckBox.Checked);
        }

        private string LogToLn(string oldExpr)
        {
            Regex logExpr = new Regex(@"(?is)\blog\((?>[^()]|(?<c>)\(|(?<-c>)\))*(?(c)(?!))\)");

            string expr = oldExpr;
            string newExpr = expr;
            do
            {
                expr = newExpr;
                newExpr = logExpr.Replace(expr, m => $"(ln({m.Value.Substring(3)})/ln(10))");
            }
            while (newExpr != expr);
            return newExpr;
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

        private void YBoundaryAutoCheckBox_Click(object sender, RibbonControlEventArgs e)
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
            DotInitialize();

            try
            {
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
            DotInitialize();

            try
            {
                Variable x = variableEditBox.Text;
                Entity expr = expressionEditBox.Text;
                Drawer drawer = new Drawer(x, expr);
                drawer.DrawingTangentLine();

                if (isAlsoDrawDotCheckBox.Checked)
                    drawer.Ploting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다음 오류가 발생했습니다.\n 정상 작업임에도 반복되면 제작자에게 다음 에러메세지와 함께 문의하세요.\nError: " + ex.Message);
            }
        }

        private float[] StringToFloatArray(string str) => str.ToString().Split(',').Select(it => Convert.ToSingle(it.Trim())).ToArray();


        private string BoundaryCheck(string str, string initialValue = Constants.INITIAL_INTERVAL)
        {
            try
            {
                float[] boundary = StringToFloatArray(str);
                return $"{boundary[0]}, {boundary[1]}";
            }
            catch
            {
                MessageBox.Show(ErrorText.COORDINATE);
                return initialValue;
            }
        }

        private string IntegerCheck(string str, string errorText, int initialValue = 0)
        {
            try
            {
                return Convert.ToInt32(str).ToString();
            }
            catch
            {
                MessageBox.Show(errorText);
                return initialValue.ToString();
            }
        }

        private string FloatCheck(string str, string errorText, float initialValue = 0f)
        {
            try
            {
                return Convert.ToSingle(str).ToString();
            }
            catch
            {
                MessageBox.Show(errorText);
                return initialValue.ToString();
            }
        }



        private void Precision_TextChanged(object sender, RibbonControlEventArgs e)
        {
            precision.Text = IntegerCheck(precision.Text, ErrorText.PRECISION, Constants.INITIAL_PRECISION);
            precision.Text = Math.Max(Math.Min(Convert.ToInt32(precision.Text), Constants.MAX_PRECISION), Constants.MIN_PRECISION).ToString();
        }

        private void ZoomSize_TextChanged(object sender, RibbonControlEventArgs e)
        {
            float decimalToPercent(float d) => d * 100;

            zoomSize.Text = FloatCheck(zoomSize.Text, ErrorText.ZOOM_RATIO, decimalToPercent(Constants.INITIAL_RATIO));
            zoomSize.Text = Math.Max(Math.Min(Convert.ToInt32(zoomSize.Text), decimalToPercent(Constants.MAX_RATIO)), decimalToPercent(Constants.MIN_RATIO)).ToString();
        }

        


        private void XAxisBoundary_TextChanged(object sender, RibbonControlEventArgs e)
        {
            xAxisBoundary.Text = BoundaryCheck(xAxisBoundary.Text);

            if (isYBoundaryAutoCheckBox.Checked)
            {
                yAxisBoundary.Text = xAxisBoundary.Text;
            }
            if (isDomainAutoCheckBox.Checked)
            {
                domainBoundary.Text = xAxisBoundary.Text;
            }
        }

        private void YAxisBoundary_TextChanged(object sender, RibbonControlEventArgs e)
        {
            yAxisBoundary.Text = BoundaryCheck(yAxisBoundary.Text);
        }

        private void DotCoordinate_TextChanged(object sender, RibbonControlEventArgs e)
        {
            dotCoordinate.Text = BoundaryCheck(dotCoordinate.Text);
        }

        private void IntegralConstant_TextChanged(object sender, RibbonControlEventArgs e)
        {
            integralConstant.Text = FloatCheck(integralConstant.Text, ErrorText.INTEGRAL_CONSTANT);
        }


        private void SingularPointAccuracy_TextChanged(object sender, RibbonControlEventArgs e)
        {
            singularPointAccuracy.Text = IntegerCheck(singularPointAccuracy.Text, ErrorText.SINGULAR_POINT_ACCURACY, Constants.INITIAL_SINGULAR_POINT_ACCURACY);
            singularPointAccuracy.Text = Math.Max(Math.Min(Convert.ToInt32(singularPointAccuracy.Text), Constants.MAX_SINGULAR_POINT_ACCURACY), Constants.MIN_SINGULAR_POINT_ACCURACY).ToString();
        }

        private void IsDomainAutoCheckBox_Click(object sender, RibbonControlEventArgs e)
        {
            if (isDomainAutoCheckBox.Checked)
            {
                domainBoundary.Enabled = false;
                domainBoundary.Text = xAxisBoundary.Text;
            }
            else
            {
                domainBoundary.Enabled = true;
            }
        }

        private void DomainBoundary_TextChanged(object sender, RibbonControlEventArgs e)
        {
            domainBoundary.Text = BoundaryCheck(domainBoundary.Text);
        }

        private void IsAccurateCriticalPointCheckBox_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void IsAccurateSingularPointCheckBox_Click(object sender, RibbonControlEventArgs e)
        {
            if (isAccurateSingularPointCheckBox.Checked)
            {
                singularPointAccuracy.Enabled = true;
                singularPointAccuracy.Text = Constants.INITIAL_SINGULAR_POINT_ACCURACY.ToString();
            }
            else
            {
                singularPointAccuracy.Text = Constants.MIN_SINGULAR_POINT_ACCURACY.ToString();
                singularPointAccuracy.Enabled = false;
            }
        }

        private void IsAllowedDynamicPlotting_Click(object sender, RibbonControlEventArgs e)
        {
            if (isAllowedDynamicPlotting.Checked)
            {
                isAccurateCriticalPointCheckBox.Enabled = true;
                isAccurateCriticalPointCheckBox.Checked = true;
                isOverclocked.Enabled = true;
            }
            else
            {
                isAccurateCriticalPointCheckBox.Enabled = false;
                isAccurateCriticalPointCheckBox.Checked = false;
                isOverclocked.Enabled = false;
            }
        }

        private void IsOverclocked_Click(object sender, RibbonControlEventArgs e)
        {
            if (isOverclocked.Checked)
            {
                precision.Enabled = false;
                isAccurateSingularPointCheckBox.Enabled = false;
                singularPointAccuracy.Enabled = false;
                isAccurateCriticalPointCheckBox.Enabled = false;
                isAllowedDynamicPlotting.Enabled = false;
                precision.Text = Constants.OVERCLOCKED_PRECISION.ToString();
                isAccurateSingularPointCheckBox.Checked = true;
                isAccurateCriticalPointCheckBox.Checked = false;
                singularPointAccuracy.Text = Constants.OVERCLOCKED_SINGULAR_POINT_ACCURACY.ToString();
            }
            else
            {
                precision.Enabled = true;
                isAccurateSingularPointCheckBox.Enabled = true;
                singularPointAccuracy.Enabled = true;
                isAccurateCriticalPointCheckBox.Enabled = true;
                isAllowedDynamicPlotting.Enabled = true;
                precision.Text = Constants.INITIAL_PRECISION.ToString();
                singularPointAccuracy.Text = Constants.INITIAL_SINGULAR_POINT_ACCURACY.ToString();
            }

        }
    }
}
