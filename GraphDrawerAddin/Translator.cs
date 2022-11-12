namespace GraphDrawerAddin
{

    internal class Translator
    {
        public float X { get; }
        public float Y { get; }

        public Translator(float X, float Y)
        {
            this.X = Constants.TRANSLATE_X + X;
            this.Y = Constants.TRANSLATE_Y - Y;
        }
    }

    internal class AffineMapper
    {
        public float X { get; }
        public float Y { get; }

        public AffineMapper(float X, float Y)
        {
            this.X = (X - Settings.XMin) / (Settings.XMax - Settings.XMin) 
                * Constants.COORDINATE_HEIGHT * Settings.ZoomProp;
            this.Y = (Y - Settings.YMin) / (Settings.YMax - Settings.YMin) 
                * Constants.COORDINATE_WIDTH * Settings.YStretch * Settings.ZoomProp;
        }
    }
}
