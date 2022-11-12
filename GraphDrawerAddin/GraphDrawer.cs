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
    public partial class GraphDrawer
    {
        private void GraphDrawer_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void graphGeneratorButton_Click(object sender, RibbonControlEventArgs e)
        {
            Variable x = variableEditBox.Text;
            Entity expr = expressionEditBox.Text;
            Drawer drawer = new Drawer(x, expr);

            try
            {
                drawer.Drawing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ");
                throw new Exception("Error: ", ex);
                
            }
            finally
            {
                
            }

        }
    }
}
