using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace GraphDrawerAddin
{
    internal static class Extension
    {
        public static PowerPoint.LineFormat ApplyArrowStyleLine(this PowerPoint.LineFormat line)
        {
            line.ForeColor.RGB = Color.BLACK;
            line.EndArrowheadStyle = Office.MsoArrowheadStyle.msoArrowheadStealth;
            line.EndArrowheadLength = Office.MsoArrowheadLength.msoArrowheadLong;
            return line;
        }

        public static PowerPoint.LineFormat ApplyDashedStyleLine(this PowerPoint.LineFormat line)
        {
            line.ForeColor.RGB = Color.BLACK;
            line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            return line;
        }

        public static PowerPoint.Shape ApplyBoldStyleGraph(this PowerPoint.Shape shape)
        {
            shape.Line.ForeColor.RGB = Color.BLACK;
            shape.Line.Weight = Style.LINE_BOLD;
            return shape;
        }

        public static PowerPoint.Shape ApplyEquationText(this PowerPoint.Shape shape, string equation, bool isItalic = true)
        {
            shape.TextFrame.TextRange.Text = equation;
            shape.TextEffect.FontName = Style.FONT_NAME;
            if (isItalic)
                shape.TextEffect.FontItalic = Office.MsoTriState.msoTrue;
            return shape;
        }

        public static PowerPoint.Shape ApplyBoldStyleDot(this PowerPoint.Shape shape)
        {
            shape.Line.ForeColor.RGB = Color.BLACK;
            shape.Fill.ForeColor.RGB = Color.BLACK;
            shape.Line.Weight = Style.LINE_BOLD;
            return shape;
        }


        public static PowerPoint.Shape TransformedAddLine(this PowerPoint.Shapes shapes, float BeginX, float BeginY, float EndX, float EndY)
        {
            PixelAffineMapper Mbegin = new PixelAffineMapper(BeginX, BeginY);
            Translator begin = new Translator(Mbegin.X, Mbegin.Y);
            PixelAffineMapper MEnd = new PixelAffineMapper(EndX, EndY);
            Translator end = new Translator(MEnd.X, MEnd.Y);
            return shapes.AddLine(begin.X, begin.Y, end.X, end.Y);
        }

        public static PowerPoint.FreeformBuilder TransformedBuildFreeform(this PowerPoint.Shapes shape, float X, float Y)
        {
            PixelAffineMapper m = new PixelAffineMapper(X, Y);
            Translator t = new Translator(m.X, m.Y);
            return shape.BuildFreeform(Office.MsoEditingType.msoEditingCorner, t.X, t.Y);
        }

        public static void TransformedAddNodes(this PowerPoint.FreeformBuilder freeformBuilder, float X, float Y)
        {
            PixelAffineMapper m = new PixelAffineMapper(X, Y);
            Translator t = new Translator(m.X, m.Y);
            freeformBuilder.AddNodes(Office.MsoSegmentType.msoSegmentCurve,
                                    Office.MsoEditingType.msoEditingAuto,
                                    t.X, t.Y);
        }

        public static PowerPoint.Shape TransformedAddTextbox(this PowerPoint.Shapes shape, float X, float Y, float W, float H, float ExtraXpxl, float ExtraYpxl) {
            PixelAffineMapper m = new PixelAffineMapper(X, Y);
            Translator t = new Translator(m.X, m.Y);
            t.ExtraTranslate(ExtraXpxl, ExtraYpxl);
            return shape.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal,
                t.X, t.Y, W, H);
        }

        public static PowerPoint.Shape TransformedAddDot(this PowerPoint.Shapes shape, float X, float Y)
        {
            PixelAffineMapper m = new PixelAffineMapper(X, Y);
            Translator t = new Translator(m.X, m.Y);
            return shape.AddShape(Office.MsoAutoShapeType.msoShapeOval,
                t.X - Constants.DOT_RADIUS, t.Y - Constants.DOT_RADIUS, 2 * Constants.DOT_RADIUS, 2 * Constants.DOT_RADIUS);
        }
    }
}
