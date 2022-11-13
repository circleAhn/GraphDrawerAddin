namespace GraphDrawerAddin
{

    internal class Translator
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Translator(float X, float Y)
        {
            this.X = Constants.TRANSLATE_X_PXL + X;
            this.Y = Constants.TRANSLATE_Y_PXL - Y;
        }

        public void ExtraTranslate(float X, float Y)
        {
            this.X += X;
            this.Y += Y;
        }
    }

    internal class PixelAffineMapper
    {
        public float X { get; }
        public float Y { get; }

        public PixelAffineMapper(float X, float Y)
        {
            this.X = (X - Settings.XMin) / (Settings.XMax - Settings.XMin) 
                * Constants.COORDINATE_HEIGHT_PXL * Settings.ZoomProp;
            this.Y = (Y - Settings.YMin) / (Settings.YMax - Settings.YMin) 
                * Constants.COORDINATE_WIDTH_PXL * Settings.YStretch * Settings.ZoomProp;
        }
    }
}
