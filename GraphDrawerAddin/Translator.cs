using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDrawerAddin
{

    internal class Translator
    {
        public float X { get; }
        public float Y { get; }

        public Translator (float X, float Y)
        {
            this.X = Constants.TRANSLATE_X + X;
            this.Y = Constants.TRANSLATE_Y - Y;
        }
    }
}
