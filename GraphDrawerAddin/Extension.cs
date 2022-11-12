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

        public static PowerPoint.Shape ApplyBoldStyleGraph(this PowerPoint.Shape shape)
        {
            shape.Line.ForeColor.RGB = Color.BLACK;
            shape.Line.Weight = Style.LINE_BOLD;
            return shape;
        }


        public static PowerPoint.Shape TranslatedAddLine(this PowerPoint.Shapes shapes, float BeginX, float BeginY, float EndX, float EndY)
        {
            Translator begin = new Translator(BeginX, BeginY);
            Translator end = new Translator(EndX, EndY);
            return shapes.AddLine(begin.X, begin.Y, end.X, end.Y);
        }

        public static PowerPoint.FreeformBuilder TranslatedBuildFreeform(this PowerPoint.Shapes shape, float X, float Y)
        {
            Translator t = new Translator(X, Y);
            return shape.BuildFreeform(Office.MsoEditingType.msoEditingCorner, t.X, t.Y);
        }

        public static void TranslatedAddNodes(this PowerPoint.FreeformBuilder freeformBuilder, float X, float Y)
        {
            Translator t = new Translator(X, Y);
            freeformBuilder.AddNodes(Office.MsoSegmentType.msoSegmentCurve,
                                    Office.MsoEditingType.msoEditingAuto,
                                    t.X, t.Y);
        }
    }
}
