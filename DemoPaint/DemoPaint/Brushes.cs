using System.Windows.Media;

namespace DemoPaint
{
    internal class Brushes
    {
        public Fills FillType = Fills.NoFill;
        public DoubleCollection OutLineType = new DoubleCollection() { 1, 0 };
        public int currSize = 3;
        public bool selectedButtonColor1 = true;
        public Brush ColorOutLineBrush = System.Windows.Media.Brushes.Black;
        public Brush ColorFillBrush = System.Windows.Media.Brushes.White;
        public FontFamily currFont = new FontFamily("Arial");

        public Brush getFillBrush()
        {
            Color cl1 = ((SolidColorBrush)(ColorOutLineBrush)).Color;
            Color cl2 = ((SolidColorBrush)(ColorFillBrush)).Color;
            switch (FillType)
            {
                case Fills.NoFill:
                    return System.Windows.Media.Brushes.Transparent;

                case Fills.Solid:
                    if (selectedButtonColor1)
                        return new SolidColorBrush(cl1);
                    else
                        return new SolidColorBrush(cl2);

                case Fills.Linear:
                    return new LinearGradientBrush(cl1, cl2, 1);

                case Fills.Radial:
                    return new RadialGradientBrush(cl1, cl2);

                default:
                    return new SolidColorBrush(cl1);
            }
        }
    }
}